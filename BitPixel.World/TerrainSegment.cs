namespace BitPixel.World
{
	public struct TerrainSegment
	{
		private readonly float _height;

		public TerrainSegment(float height)
		{
			_height = height;
		}

		public float Height
		{
			get { return _height; }
		}
	}
}