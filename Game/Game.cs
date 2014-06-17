using BitPixel;
using BitPixel.World;
using BitPixel.Graphics.Renderers;

namespace Game
{
	internal class Game
	{
		private readonly GameWindow _gameWindow;
		private readonly World _world;
		private readonly WorldRenderer _worldRenderer;

		public Game()
		{
			// Set up the game loop
			_gameWindow = new GameWindow();
			_gameWindow.Render += OnRender;

			// Set up a test world
			_world = new World();
			_world.Terrain.GenerateChunk(0);
			_world.Terrain.GenerateChunk(1);
			_world.Terrain.GenerateChunk(2);
			_world.Terrain.GenerateChunk(3);
		}

		void OnRender(object sender, GameLoopEventArgs e)
		{
			_world.Render(_worldRenderer);
		}

		public void Run()
		{
			// Run the game loop
			_gameWindow.Start();
		}
	}
}