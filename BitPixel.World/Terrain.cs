namespace BitPixel.World
{
	public class Terrain
	{
		public void GenerateChunk(int chunkLocation)
		{
		}

		public void Render(IWorldRenderer renderer)
		{
			renderer.Render(this);
		}
	}
}