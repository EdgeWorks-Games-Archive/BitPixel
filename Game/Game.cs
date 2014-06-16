using System;
using BitPixel;
using BitPixel.World;

namespace Game
{
	internal class Game
	{
		private readonly GameLoop _gameLoop;
		private readonly World _world;

		public Game()
		{
			// Set up the game loop
			_gameLoop = new GameLoop();
			_gameLoop.Render += OnRender;

			// Set up a test world
			_world = new World();
		}

		private void OnRender(object sender, EventArgs e)
		{
			_world.Render();
		}

		public void Run()
		{
			// Run the game loop
			_gameLoop.Start();
		}
	}
}