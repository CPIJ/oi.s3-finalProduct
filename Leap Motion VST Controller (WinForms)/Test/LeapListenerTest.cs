using System.Diagnostics;
using System.Drawing;
using Leap;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test
{
	[TestClass]
	public class LeapListenerTest
	{

		private LeapListener listener;
		private Mock<Controller> controller;
		private Mock<MouseController> mouse;
		private Mock<Stopwatch> timer;

		[TestInitialize]
		public void Init()
		{
			controller = new Mock<Controller>();
			mouse = new Mock<MouseController>();
			timer = new Mock<Stopwatch>();

			listener = new LeapListener(controller.Object, mouse.Object, timer.Object);
		}

		[TestMethod]
		public void test()
		{
			var kaas = listener;
		}
	}
}