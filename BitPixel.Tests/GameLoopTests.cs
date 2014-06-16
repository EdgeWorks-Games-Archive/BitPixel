using System.Threading;
using Xunit;

namespace BitPixel.Tests
{
	public class GameLoopTests
	{
		private readonly GameLoop _gameLoop = new GameLoop();

		[Fact]
		public void DoesNotRunAsync()
		{
			RunEngine(_gameLoop);

			Assert.False(_gameLoop.IsRunning);
		}

		[Fact]
		public void LoopEventsFire()
		{
			bool updateFired = false, renderFired = false;
			_gameLoop.Update += (s, e) => updateFired = true;
			_gameLoop.Render += (s, e) => renderFired = true;

			if (!RunEngine(_gameLoop))
				Assert.True(false, "Engine failed to stop in time.");

			Assert.True(updateFired);
			Assert.True(renderFired);
		}

		private static bool RunEngine(GameLoop engine, int amountOfFrames = 1, int timeout = 500)
		{
			var i = 0;

			// Make sure the engine stops after the required amount of frames
			engine.Update += (s, e) =>
			{
				i++;
				if (i >= amountOfFrames)
					engine.Stop();
			};

			// Start the engine on a separate thread
			var thread = new Thread(engine.Start);
			thread.Start();

			// Give the thread some time
			if (thread.Join(timeout))
				return true;

			// Thread timed out, force quit
			thread.Abort();
			return false;
		}
	}
}