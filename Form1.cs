using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecialCampaignSkillCoolDown
{
	public partial class Form1 : Form
	{
		// 가비지 컬랙션으로 인한 훅 삭제 방지
		private static int inputKey = 0;

		// hook state
		private static bool hookState = false;

		// 쿨타임 돌고 있는 스킬들
		private static List<leftSkillCoolDownClass> leftSkillCoolDown = new List<leftSkillCoolDownClass>();
		private object leftSkillCoolDownLock = new object();


		[DllImport("user32.dll")]
		static extern bool keybd_event(uint bVk, uint bScan, uint dwFlags, int dwExtraInfo);


		[DllImport("user32.dll")]
		static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);


		[DllImport("user32.dll")]
		static extern bool UnhookWindowsHookEx(IntPtr hInstance);


		[DllImport("user32.dll")]
		static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);


		[DllImport("kernel32.dll")]
		static extern IntPtr LoadLibrary(string lpFileName);


		private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

		private LowLevelKeyboardProc _proc = hookProc;


		private static IntPtr hhook = IntPtr.Zero;


		public void SetHook()
		{
			hookState = true;
			LBHookState.Text = "감지 중";
			IntPtr hInstance = LoadLibrary("User32");
			hhook = SetWindowsHookEx(13, _proc, hInstance, 0);
		}


		public static void UnHook()
		{
			hookState = false;
			UnhookWindowsHookEx(hhook);
		}

		public static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
		{
			if (code >= 0 && wParam == (IntPtr)0x100)
			{
				int key = Marshal.ReadInt32(lParam);

				inputKey = key;
			}
			return CallNextHookEx(hhook, code, (int)wParam, lParam);
		}

		// 설정
		private SetData data = SetData.GetInstance();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			InPutKeyControll.Enabled = true;

			if (!data.ReadSettingData())
			{
				data.SaveSettingData();
			}

			SetHook();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			InPutKeyControll.Enabled = false;
			UnHook();
		}

		private void BTGameMode_Click(object sender, EventArgs e)
		{
			// 상단바 및 버튼 안보이게 하기
			this.FormBorderStyle = FormBorderStyle.None;
			BTGameMode.Visible = false;
			BTSetting.Visible = false;
			BTClear.Visible = false;
		}

		private void BTSetting_Click(object sender, EventArgs e)
		{
			UnHook();
			settForm settt = new settForm();
			settt.ShowDialog();
			SetHook();
		}

		private void controllLeftSkillCoolDown(leftSkillCoolDownClass skill)
		{
			lock(leftSkillCoolDownLock)
			{
				string name = "";
				long time = 0;
				bool runAble = false;

				// 화면갱신
				if (skill == null)
				{
                    for(int i = 0; i < leftSkillCoolDown.Count; i++)
					{
						leftSkillCoolDown[i].GetLeftCoolDown(ref name, ref time, ref runAble);

						if(runAble)
						{
							LBCoolDown.Items[i] = name + "(RUN) : " + string.Format("{0:0.0}", (float)time / 1000);
							continue;
						}

						if(time < 0)
						{
							leftSkillCoolDown.Remove(leftSkillCoolDown[i]);
							LBCoolDown.Items.RemoveAt(i);
							continue;
						}

						LBCoolDown.Items[i] = name + " : " + string.Format("{0:0.0}", (float)time / 1000);
					}
					return;
				}

				// 스킬 쿨 추가 중복 방지
				for(int i = 0; i < leftSkillCoolDown.Count; i++)
				{
					if(skill.name == leftSkillCoolDown[i].name) { return; }
				}
				leftSkillCoolDown.Add(skill);
				skill.GetLeftCoolDown(ref name, ref time, ref runAble);
				LBCoolDown.Items.Add(name + "(RUN) : " + string.Format("{0:0.0}", (float)time / 1000));
			}
		}

		private void TimerSkillCoolDown_Tick(object sender, EventArgs e)
		{
			controllLeftSkillCoolDown(null);
		}

		private void InPutKeyControll_Tick(object sender, EventArgs e)
		{
			if (inputKey == 27)
			{
				// 상단바 및 버튼 보이게 하기
				this.FormBorderStyle = FormBorderStyle.FixedSingle;
				BTGameMode.Visible = true;
				BTSetting.Visible = true;
				BTClear.Visible = true;
			}

			else if(inputKey == data.intGameMode)
			{
				// 상단바 및 버튼 안보이게 하기
				this.FormBorderStyle = FormBorderStyle.None;
				BTGameMode.Visible = false;
				BTSetting.Visible = false;
				BTClear.Visible = false;
			}

			// 훅 잠금
			else if(inputKey == data.intHookPause)
			{
				if(hookState)
				{
					LBHookState.Text = "감지 해제";
					hookState = false;
				}
				else
				{
					LBHookState.Text = "감지 중";
					hookState = true;
				}
			}

			else if (inputKey != 0 && hookState)
			{
				for(int i = 0; i < 10; i++)
				{
					if (data.skillEnable[i] && data.intSkillBind[i] == inputKey)
					{
						controllLeftSkillCoolDown(
							new leftSkillCoolDownClass(
								data.skillUnique[i],
								data.skillName[i],
								data.skillCoolDown[i] * 1000,
								data.skillDuration[i] * 1000));
					}
				}
			}

			inputKey = 0;
		}

		private void BTClear_Click(object sender, EventArgs e)
		{
			leftSkillCoolDown.Clear();
			LBCoolDown.Items.Clear();
		}
	}

	class leftSkillCoolDownClass
    {
		public bool unique = false;
		public string name = "";
		public long coolDown = 0;   // ms, 1000ms == 1s
		public long duration = 0;   // ms, 1000ms == 1s
		private Stopwatch Stopwatch = new Stopwatch();

		private leftSkillCoolDownClass() { }
		public leftSkillCoolDownClass(bool unique, string name, long coolDown, long duration)
		{
			this.unique = unique;
			this.name = name;
			this.coolDown = coolDown;
			this.duration = duration;

			Stopwatch.Start();
		}
		~leftSkillCoolDownClass()
		{
			Stopwatch.Stop();
		}

		private object locker = new object();

		public void GetLeftCoolDown(ref string name, ref long time, ref bool runAble)
		{
			lock(locker)
			{
				name = this.name;
				if(duration > Stopwatch.ElapsedMilliseconds)
				{
					time = duration - Stopwatch.ElapsedMilliseconds;
					runAble = true;
					return;
				}
				if (unique)
				{
					time = coolDown + duration - Stopwatch.ElapsedMilliseconds;
				}
				else
				{
					time = coolDown - Stopwatch.ElapsedMilliseconds;
				}
				runAble = false;
			}
		}
    }
}