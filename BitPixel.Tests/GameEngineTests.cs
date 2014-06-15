using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	    public void TickrateIsAtTarget()
	    {
		    var elapsedList = new List<TimeSpan>();
		    var timer = new Stopwatch();

		    var target = TimeSpan.FromSeconds(1/20f);
		    var allowedVariation = TimeSpan.FromMilliseconds(1);

			_engine.TargetDelta = target;

			var mock = new Mock<IEngineComponent>();
			mock.Setup(c => c.Update(It.IsAny<float>())).Callback(() =>
			{
				// A bit of sleep so it needs to compensate
				Thread.Sleep(4);

				if (!timer.IsRunning)
				{
					timer.Start();
				}
				else
				{
					elapsedList.Add(timer.Elapsed);
					timer.Restart();
				}
			});
			_engine.AddComponent(mock.Object);

		    if (!RunEngine(4))
				Assert.True(false, "Engine failed to stop in time.");

			// Check all the frame deltas
		    foreach (var elapsed in elapsedList)
		    {
				Assert.InRange(elapsed, target - allowedVariation, target + allowedVariation);
		    }
	    }

		[Fact]
	    public void ComponentsGetUpdated()
	    {
			var mock = new Mock<IEngineComponent>();
			mock.Setup(c => c.Update(It.IsAny<float>())).Verifiable();
			_engine.AddComponent(mock.Object);

			if (!RunEngine())
				Assert.True(false, "Engine failed to stop in time.");
			
			mock.VerifyAll();
	    }

	    private bool RunEngine(int amountOfFrames = 1, int timeout = 500)
	    {
		    var i = 0;
		    var retVal = true;

			// Add a component that will stop the engine immediately
			var mock = new Mock<IEngineComponent>();
			mock.Setup(c => c.Update(It.IsAny<float>())).Callback(() =>
			{
				i++;
				if (i >= amountOfFrames)
					_engine.Stop();
			});
			_engine.AddComponent(mock.Object);

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
			_engine.RemoveComponent(mock.Object);

			return retVal;
	    }
    }
}
