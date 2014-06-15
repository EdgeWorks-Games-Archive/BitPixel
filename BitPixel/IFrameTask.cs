using System;

namespace BitPixel
{
	public interface IFrameTask
	{
		void Execute(TimeSpan delta);
	}
}