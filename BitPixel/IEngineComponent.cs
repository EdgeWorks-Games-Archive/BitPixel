using System.Collections.Generic;

namespace BitPixel
{
	public interface IEngineComponent
	{
		IEnumerable<IFrameTask> FrameTasks { get; }
	}
}