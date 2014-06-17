namespace BitPixel.World
{
	public struct TerrainLine
	{
		private readonly int _height;

		public TerrainLine(int height)
		{
			_height = height;
		}

		public int Height
		{
			get { return _height; }
		}
	}
}