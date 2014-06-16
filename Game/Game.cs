using BitPixel;
using BitPixel.World;

namespace Game
{
	internal class Game
	{
		private readonly GameWindow _gameWindow;
		private readonly World _world;

		public Game()
		{
			// Set up the game loop
			_gameWindow = new GameWindow();

			// Set up a test world
			_world = new World();
		}

		public void Run()
		{
			// Run the game loop
			_gameWindow.Start();
		}
	}
}