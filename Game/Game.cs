using BitPixel;
using BitPixel.World;
using BitPixel.World.Graphics;

namespace Game
{
	internal class Game
	{
		private readonly GameWindow _gameWindow;
		private readonly WorldRenderer _renderer;
		private readonly World _world;

		public Game()
		{
			// Set up the game loop
			_gameWindow = new GameWindow();
			_gameWindow.Render += OnRender;

			// Set up a test world
			_world = new World();

			_renderer = new WorldRenderer();
		}

		private void OnRender(object sender, GameLoopEventArgs e)
		{
			_world.Render(_renderer);
		}

		public void Run()
		{
			// Run the game loop
			_gameWindow.Start();
		}
	}
}