using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCampaignSkillCoolDown
{
	internal class KeybordHooker
	{
		private static KeybordHooker _instance;
		public static KeybordHooker GetKeybordHooker()
		{
			if (_instance == null)
			{
				_instance = new KeybordHooker();
			}
			return _instance;
		}
		private KeybordHooker() { }

		// hook state
		private static bool _hookState = false;
		public bool GetHookState () { return _hookState; }
		public void SetHookState (bool state) { _hookState = state; }

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

		private LowLevelKeyboardProc _proc = HookProc;


		private static IntPtr _hhook = IntPtr.Zero;

		public void SetHook()
		{
			_hookState = false;
			IntPtr hInstance = LoadLibrary("User32");
			_hhook = SetWindowsHookEx(13, _proc, hInstance, 0);
		}


		public void UnHook()
		{
			_hookState = true;
			UnhookWindowsHookEx(_hhook);
		}

		public static IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam)
		{
			UpdataKeybordHook(Marshal.ReadInt32(lParam), wParam);

			return CallNextHookEx(_hhook, code, (int)wParam, lParam);
		}

		// event
		public static EventHandler<KeybordHookEventArg> UpdataKeybordHookEvent;
		public class KeybordHookEventArg : EventArgs
		{
			public int _keyCode;
			public IntPtr _lParam;
		}
		public static void UpdataKeybordHook(int keyCode, IntPtr intPtr)
		{
			UpdataKeybordHookEvent.Invoke(_instance, new KeybordHookEventArg()
			{
				_keyCode = keyCode,
				_lParam = intPtr,
			});
		}
	}
}
