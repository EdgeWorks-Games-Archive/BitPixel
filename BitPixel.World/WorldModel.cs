namespace BitPixel.World
{
	internal class WorldModel
	{
		public WorldModel()
		{
			// A world intrinsically always will have a terrain.
			// Giving it a new terrain would mess with other parts of the world, so it's safer if we don't allow that.
			Terrain = new Terrain();
		}

		public Terrain Terrain { get; private set; }
	}
}