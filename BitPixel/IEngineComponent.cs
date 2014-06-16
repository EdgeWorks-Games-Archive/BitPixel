using System;

namespace BitPixel
{
	public interface IEngineComponent
	{
		void Update(TimeSpan delta);
	}
}