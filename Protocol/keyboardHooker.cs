using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SpecialCampaignSkillCoolDown
{
	internal class keyboardHooker
	{
		private static keyboardHooker _instance;
		public static keyboardHooker GetKeyboardHooker()
		{
			if (_instance == null)
			{
				_instance = new keyboardHooker();
			}
			return _instance;
		}
		private keyboardHooker() { }

		// hook state
		private static bool _hookState = false;
		public bool GetHookState() { return _hookState; }
		public void SetHookState(bool state) { _hookState = state; }

		// 차단될 키
		private static List<int> _blockKey = new List<int>();
		public void SetBlockKey(List<int> list)
		{
			_blockKey = list;
		}

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
			UpdataKeyboardHook(Marshal.ReadInt32(lParam), wParam);

			// key block
			if (!_hookState && _blockKey.Contains(Marshal.ReadInt32(lParam)))
			{
				return (IntPtr)1;
			}

			return CallNextHookEx(_hhook, code, (int)wParam, lParam);
		}

		// event
		public static EventHandler<KeyboardHookEventArg> UpdataKeyboardHookEvent;
		public class KeyboardHookEventArg : EventArgs
		{
			public int _keyCode;
			public IntPtr _lParam;
		}
		public static void UpdataKeyboardHook(int keyCode, IntPtr intPtr)
		{
			UpdataKeyboardHookEvent.Invoke(_instance, new KeyboardHookEventArg()
			{
				_keyCode = keyCode,
				_lParam = intPtr,
			});
		}
	}
}
