namespace BitPixel.World
{
	public class WorldController
	{
		private WorldModel _model;
		private readonly WorldView _view;

		public WorldController(GameLoop gameLoop)
		{
			_view = new WorldView();
		}

		public void GenerateNewWorld(int chunks)
		{
			_model = new WorldModel();

			for (var i = 0; i < chunks; i++)
				_model.Terrain.GenerateChunk(i);
		}
	}
}