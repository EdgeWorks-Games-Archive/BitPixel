using System;
using BitPixel;
using BitPixel.World;

namespace Game
{
	internal static class Program
	{
		private static void Main()
		{
			// Set up the game loop
			var gameLoop = new GameLoop
			{
				TargetFrameDelta = TimeSpan.FromSeconds(1/60f)
			};

			// Set up a test world
			var world = new WorldController(gameLoop);
			world.GenerateNewWorld(8);

			// Run the game loop
			gameLoop.Start();
		}
	}
}