using System;
using System.Diagnostics;

namespace BitPixel.World
{
	public class World
	{
		public World()
			: this((int) DateTime.Now.Ticks)
		{
		}

		public World(int seed)
		{
			Trace.TraceInformation("Generating new world with seed {0}...", seed);
			
			// These properties will have to be fixed always not null.
			// They can not be reset since they depend on eachother.
			// For example, the Structures' pathfinding graphs depend on the Terrain.
			Terrain = new Terrain(seed);

			Trace.TraceInformation("Finished generating world.");
		}

		public Terrain Terrain { get; private set; }

		public void Render(IWorldRenderer renderer)
		{
			Terrain.Render(renderer);
		}
	}
}