using System.Threading;
using Moq;
using Xunit;

namespace BitPixel.Tests
{
    public class GameEngineTests
    {
		[Fact]
	    public void ComponentsUpdateAndRender()
	    {
		    using (var engine = new GameEngine())
		    {
				var mock = new Mock<IEngineComponent>();
				mock.Setup(c => c.Update(It.IsAny<float>())).Verifiable();
			    mock.Setup(c => c.Render(It.IsAny<float>())).Verifiable();

				engine.AddComponent(Mock.Of<IEngineComponent>());
			    RunEngineOnce(engine);

				mock.VerifyAll();
		    }
	    }

	    private void RunEngineOnce(GameEngine engine)
	    {
			// Add a component that will stop the engine immediately
			var mock = new Mock<IEngineComponent>();
			mock.Setup(c => c.Update(It.IsAny<float>())).Callback(engine.Stop);
			engine.AddComponent(mock.Object);

			// Start the engine on a separate thread
			var thread = new Thread(engine.Start);
			thread.Start();

			// Give the thread some time
		    if (!thread.Join(100))
		    {
			    // Thread timed out, force quit and report the failure
			    thread.Abort();
			    Assert.False(false, "Engine failed to stop in time.");
		    }

			// Clean up
		    engine.RemoveComponent(mock.Object);
	    }
    }
}
