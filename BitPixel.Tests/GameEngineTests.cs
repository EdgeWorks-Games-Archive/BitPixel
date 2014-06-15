using System;
using System.Collections.Generic;
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
		public void ComponentFrametasksGetRun()
		{
			var mock = new Mock<IFrameTask>();
			mock.Setup(t => t.Execute(It.IsAny<TimeSpan>())).Verifiable();

			_engine.Components.Add(new TaskExecutorComponent(mock.Object));

			if (!RunEngine())
				Assert.True(false, "Engine failed to stop in time.");

			mock.VerifyAll();
		}

		private bool RunEngine(int amountOfFrames = 1, int timeout = 500)
		{
			var i = 0;
			var retVal = true;

			// Add a component that will stop the engine after the target amount of frames has been reached
			var mock = new Mock<IFrameTask>();
			mock.Setup(c => c.Execute(It.IsAny<TimeSpan>())).Callback(() =>
			{
				i++;
				if (i >= amountOfFrames)
					_engine.Stop();
			});
			var component = new TaskExecutorComponent(mock.Object);
			_engine.Components.Add(component);

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
			_engine.Components.Remove(component);

			return retVal;
		}

		private class TaskExecutorComponent : IEngineComponent
		{
			private readonly IFrameTask _task;

			public TaskExecutorComponent(IFrameTask task)
			{
				_task = task;
			}

			public IEnumerable<IFrameTask> FrameTasks
			{
				get { return new List<IFrameTask> {_task}; }
			}
		}
	}
}