namespace BitPixel.World
{
	public class Terrain
	{
		private TerrainLine[] _heights;

		public Terrain()
		{
			_heights = new TerrainLine[20];
			for (var i = 0; i < _heights.Length; i++)
			{
				_heights[i] = new TerrainLine(20);
			}
		}

		public void Render(IWorldRenderer renderer)
		{
			renderer.Render(this);
		}
	}
}