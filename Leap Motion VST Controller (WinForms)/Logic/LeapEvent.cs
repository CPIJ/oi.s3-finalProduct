using System;

namespace Logic
{
	public class LeapEvent : EventArgs
	{
		public bool IsRight { get; }
		public bool IsLeft { get; }
		public int X { get; }
		public int Y { get; }

		public LeapEvent(int x, int y, bool isLeft)
		{
			X = x;
			Y = y;
			IsLeft = isLeft;
			IsRight = !isLeft;
		}
	}
}