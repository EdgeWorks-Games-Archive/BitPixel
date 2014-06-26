using System;
using System.Linq;
using BitPixel.World;
using Xunit;

namespace BitPixel.Tests.World
{
	public class TerrainTests
	{
		[Fact]
		public void ConstructorGenerates()
		{
			var terrain = new Terrain(10);

			// Make sure anything was generated
			Assert.NotEmpty(terrain.TerrainSegments);

			// Make sure they're not all the same value
			var segmentArray = terrain.TerrainSegments.Take(2).ToArray();
			Assert.NotEqual(
				Math.Round(segmentArray[0].Height, 1),
				Math.Round(segmentArray[1].Height, 1));
		}
	}
}