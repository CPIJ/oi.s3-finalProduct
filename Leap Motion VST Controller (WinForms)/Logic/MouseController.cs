using System;
using System.Runtime.InteropServices;

namespace Logic
{
	public class MouseController
	{
		public int X { get; private set; }
		public int Y { get; private set; }
		public bool IsDown { get; private set; }
		public Os Os { get; }

		public MouseController() {}

		public MouseController(Os os)
		{
			Os = os;
		}

		public enum Button
		{
			Left, Right
		}

		public void Move(int x, int y)
		{
			X = x;
			Y = y;

			Os.MoveMouse(x, y);
		}

		public void ToggleButton(Button button, bool enable)
		{
			IsDown = enable;

			switch (button)
			{
				case Button.Left:
					Os.MouseEvent(enable ? Os.LeftDown : Os.LeftUp, (uint) X, (uint) Y, 0, 0);
					break;
				case Button.Right:
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(button), button, null);
			}
		}
	}
}