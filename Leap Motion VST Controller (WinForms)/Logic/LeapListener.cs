using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Leap;
using Screen = System.Windows.Forms.Screen;

namespace Logic
{

	public class LeapListener
	{
		public Controller Controller { get; private set; }
		public event EventHandler OnMove;
		public event EventHandler OnPinch;
		public event EventHandler OnRepaint;
		private const int Fps = 1000 / 24;
		private readonly MouseController mouse;
		private readonly Stopwatch timer;
		private readonly Rectangle bounds;

		public LeapListener() { }

		public LeapListener(Controller controller, MouseController mouse, Stopwatch timer)
		{
			Controller = controller;
			this.mouse = mouse;
			this.timer = timer;
			bounds = Screen.PrimaryScreen.Bounds;
		}

		public void EventLoop()
		{
			timer.Start();
			long lastTime = 0;

			while (true)
			{
				if (timer.ElapsedMilliseconds - lastTime <= Fps) continue;
				lastTime = timer.ElapsedMilliseconds;

				var frame = Controller.Frame();
				if (frame != null)
				{
					OnFrame(frame);
				}
			}
		}

		private void OnFrame(Frame frame)
		{
			HandleOnReset();

			foreach (var hand in frame.Hands.Where(hand => hand.IsValid))
			{
				var interactionBox = frame.InteractionBox;
				var point = interactionBox.NormalizePoint(hand.StabilizedPalmPosition);
				var screenPosition = new Vector(bounds.Width * point.x, bounds.Height - point.y * bounds.Height, 0);

				if (hand.PinchStrength > 0.8)
				{
					if (!mouse.IsDown)
					{
						mouse.ToggleButton(MouseController.Button.Left, true);
					}

					mouse.Move((int)screenPosition.x, (int)screenPosition.y);
					HandleOnPinch(screenPosition, hand.IsLeft);
				}
				else
				{
					if (mouse.IsDown)
					{
						mouse.ToggleButton(MouseController.Button.Left, false);
					}

					HandleOnMove(screenPosition, hand.IsLeft);
				}
			}
		}

		private void HandleOnMove(Vector vector, bool isLeft)
		{
			OnMove?.Invoke(this, new LeapEvent((int)vector.x, (int)vector.y, isLeft));
		}

		private void HandleOnPinch(Vector vector, bool isLeft)
		{
			OnPinch?.Invoke(this, new LeapEvent((int)vector.x, (int)vector.y, isLeft));
		}

		private void HandleOnReset()
		{
			OnRepaint?.Invoke(this, EventArgs.Empty);
		}
	}
}