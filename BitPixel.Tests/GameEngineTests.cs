using System;
using System.Threading;
using Moq;
using Xunit;

namespace BitPixel.Tests
{
	public class GameEngineTests : IDisposable
	{
		private readonly GameEngine _engine = new GameEngine();

		public void Dispose()
		{
			_engine.Dispose();
		}

		[Fact]
		public void ComponentsGetUpdated()
		{
			var mock = new Mock<IEngineComponent>();
			mock.Setup(t => t.Update(It.IsAny<TimeSpan>())).Verifiable();
			_engine.Components.Add(mock.Object);

			if (!RunEngine())
				Assert.True(false, "Engine failed to stop in time.");

			mock.VerifyAll();
		}

		private bool RunEngine(int amountOfFrames = 1, int timeout = 500)
		{
			var i = 0;
			var retVal = true;

			// Add a component that will stop the engine after the target amount of frames has been reached
			var mock = new Mock<IEngineComponent>();
			mock.Setup(c => c.Update(It.IsAny<TimeSpan>())).Callback(() =>
			{
				i++;
				if (i >= amountOfFrames)
					_engine.Stop();
			});
			_engine.Components.Add(mock.Object);

			// Start the engine on a separate thread
			var thread = new Thread(_engine.Start);
			thread.Start();

			// Give the thread some time
			if (!thread.Join(timeout))
			{
				// Thread timed out, force quit
				thread.Abort();
				retVal = false;
			}

			// Clean up
			_engine.Components.Remove(mock.Object);

			return retVal;
		}
	}
}