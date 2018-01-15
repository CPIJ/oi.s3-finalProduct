using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leap;


namespace leap_csharp
{
	class Program
	{
		private static void Main(string[] args)
		{
			var controller = new Controller();
			controller.SetPolicy(Controller.PolicyFlag.POLICY_BACKGROUND_FRAMES);
			var listener = new MyListener();
			controller.AddListener(listener);


			Console.WriteLine("Press enter to exit...");
			Console.ReadLine();

			controller.RemoveListener(listener);
		}
	}

	internal class MyListener : Listener
	{
		public override void OnFrame(Controller controller)
		{
			var frame = controller.Frame();
			var hand = frame.Hands[0];

			if (!hand.IsValid) return;

			var box = frame.InteractionBox;
			var pos = box.NormalizePoint(hand.StabilizedPalmPosition);
			var screenPos = new Vector(1920 * pos.x, 1080 - pos.y * 1080, 0);

			SetCursorPos((int)screenPos.x, (int)screenPos.y);

			if (hand.PinchStrength > 0.8)
			{
				mouse_event(LeftDown, (uint)screenPos.x, (uint)screenPos.y, 0, 0);
				//SetCursorPos((int)screenPos.x, (int)screenPos.y);
			}
			else
			{
				mouse_event(LeftUp, 0, 0, 0, 0);
			}
		}

		public override void OnFocusLost(Controller arg0)
		{
			Console.WriteLine("Lost focus");
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

		private const int LeftDown = 0x02;
		private const int LeftUp = 0x04;
	
		[DllImport("user32.dll")]
		static extern bool SetCursorPos(int x, int y);
	}
}
