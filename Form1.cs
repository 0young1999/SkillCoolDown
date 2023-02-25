using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
		[DllImport("user32.dll")]
		static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);



		[DllImport("user32.dll")]
		static extern bool UnhookWindowsHookEx(IntPtr hInstance);



		[DllImport("user32.dll")]
		static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);



		[DllImport("kernel32.dll")]
		static extern IntPtr LoadLibrary(string lpFileName);


		private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);


		const int WH_KEYBOARD_LL = 13;

		const int WM_KEYDOWN = 0x100;

		
		private IntPtr hook = IntPtr.Zero;

		// 가비지 오류 수정중 001
		private static IntPtr hInstance;


		public Form1()
		{
			InitializeComponent();
		}

		private void SetHook()
		{
			// 가비지 오류 수정중 001
			//IntPtr hInstance = LoadLibrary("User32");
			hInstance = LoadLibrary("User32");
			hook = SetWindowsHookEx(WH_KEYBOARD_LL, HookProc, hInstance, 0);
		}

		private void UnHook()
		{
			UnhookWindowsHookEx(hook);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			SetHook();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			UnHook();
		}

		private IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam)
		{
			if (code >= 0 && wParam == (IntPtr)WM_KEYDOWN)
			{
				int vkCode = Marshal.ReadInt32(lParam);

				CoolDown0.Invoke((MethodInvoker)delegate { CoolDown0.Text = vkCode.ToString(); });
			}

			return CallNextHookEx(hook, code, (int)wParam, lParam); // 키입력을 정상적으로 동작하게 합니다.
			//return (IntPtr); // 키입력을 무효화 합니다.
		}

		private void BTGameMode_Click(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.None;
			BTGameMode.Visible = false;
			BTSetting.Visible = false;

			// 삭제
			GC.Collect();
		}

		private void BTSetting_Click(object sender, EventArgs e)
		{
			GC.Collect();
		}
	}
}