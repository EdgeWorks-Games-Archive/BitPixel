using System;
using BitPixel;
using BitPixel.StateMachine;
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

			// Set up other components
			var stateMachine = new StateMachine();
			var world = new World();

			// Actually run the engine
			gameLoop.Start();
		}
	}
}