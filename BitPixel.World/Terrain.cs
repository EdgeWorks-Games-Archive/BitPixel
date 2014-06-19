using System;
using System.Collections.Generic;
using System.Diagnostics;
using SharpNoise.Modules;

namespace BitPixel.World
{
	public class Terrain
	{
		private readonly TerrainSegment[] _segments;

		public Terrain(int seed)
		{
			var perlin = new Perlin
			{
				Seed = seed
			};

			_segments = new TerrainSegment[100];
			for (var x = 0; x < _segments.Length; x++)
			{
				var heightVariation = perlin.GetValue(x*0.01f, 0, 0);
				var height = 10 + (heightVariation * 10) + 5;
				_segments[x] = new TerrainSegment((float)height);
			}
			Trace.TraceInformation("Generated {0} terrain segments!", _segments.Length);
		}

		public IEnumerable<TerrainSegment> TerrainSegments
		{
			get { return _segments; }
		}

		public void Render(IWorldRenderer renderer)
		{
			renderer.Render(this);
		}
	}
}