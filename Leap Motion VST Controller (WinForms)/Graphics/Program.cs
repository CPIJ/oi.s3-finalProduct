using System;
using System.Diagnostics;
using System.Windows.Forms;
using Leap;
using Logic;
using Screen = System.Windows.Forms.Screen;

namespace winFormsTest
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var controller = new Controller();
			var system = new Os();
			var listener = new LeapListener(controller, new MouseController(system), new Stopwatch());
			Application.Run(new MainForm(controller, listener, system));
		}
	}
}
