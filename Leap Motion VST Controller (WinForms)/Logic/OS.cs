using System;
using System.Runtime.InteropServices;

namespace Logic
{
	public class Os
	{
		public const uint LeftDown = 0x02;
		public const uint LeftUp = 0x04;

		public static readonly IntPtr TopMost = new IntPtr(-1);
		public const uint SwpNosize = 0x0001;
		public const uint SwpNomove = 0x0002;
		public const uint TopmostFlags = SwpNomove | SwpNosize;

		public void MouseEvent(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo)
		{
			mouse_event(dwFlags, dx, dy, cButtons, dwExtraInfo);
		}

		public void MoveMouse(int x, int y)
		{
			SetCursorPos(x, y);
		}

		public void SetWindowPosition(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags)
		{
			SetWindowPos(hWnd, hWndInsertAfter, X, Y, cx, cy, uFlags);
		}

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

		[DllImport("user32.dll")]
		private static extern bool SetCursorPos(int x, int y);
	}
}

