using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Leap;
using Logic;

namespace winFormsTest
{
	public partial class MainForm : Form
	{
		public Os System { get; }
		public Controller Controller { get; private set; }
		public LeapListener Listener { get; private set; }

		private Graphics graphics;
		private const int MaxR = 20;
		private const int MinR = 10;
		private int r = 10;
		private const int Increment = 6;
		private Thread eventLoopThread;
		private float angle;
		private readonly Color keyColor = Color.LimeGreen;

		public MainForm(Controller controller, LeapListener listener, Os system)
		{
			InitializeComponent();

			System = system;

			Controller = controller;
			controller.SetPolicy(Controller.PolicyFlag.POLICY_BACKGROUND_FRAMES);

			Listener = listener;
			Listener.OnPinch += OnPinch;
			Listener.OnMove += OnMove;
			Listener.OnRepaint += (sender, args) => graphics.Clear(keyColor);
		}

		private void OnPinch(object sender, EventArgs eventArgs)
		{
			var e = (LeapEvent)eventArgs;
			if (r < MaxR) r += Increment;

			DrawCircle(e.IsLeft ? Color.LightGreen : Color.LightSkyBlue, e.X, e.Y, r, true);
		}

		private void OnMove(object sender, EventArgs eventArgs)
		{
			var e = (LeapEvent)eventArgs;
			if (r > MinR) r -= Increment;

			DrawCircle(e.IsLeft ? Color.LightGreen : Color.LightSkyBlue, e.X, e.Y, r);
		}

		private void DrawCircle(Color color, float x, float y, float radius, bool animate = false)
		{
			var strokeWidth = radius / 4;

			if (animate)
			{
				if (angle >= 360) angle = 0;

				angle += 0.4f;
				strokeWidth *= (float)Math.Cos(angle);
			}

			graphics.DrawEllipse(new Pen(color, strokeWidth), x - radius, y - radius, radius * 2, radius * 2);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			canvas.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
			BackColor = keyColor;
			TransparencyKey = keyColor;
			FormBorderStyle = FormBorderStyle.None;
			WindowState = FormWindowState.Maximized;

			System.SetWindowPosition(Handle, Os.TopMost, 0, 0, 0, 0, Os.TopmostFlags);

			graphics = canvas.CreateGraphics();

			eventLoopThread = new Thread(Listener.EventLoop);
			eventLoopThread.Start();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to exit the application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				eventLoopThread.Abort();
				Close();
			}
		}
	}
}
