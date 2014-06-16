using System;
using BitPixel;
using BitPixel.Graphics;
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

			// Set up a layer manager to render layers
			var layerManager = new LayerManager<RenderLayers>(gameLoop);

			// Set up a test world
			var world = new World();
			layerManager.AddLayer(world, RenderLayers.World);

			// Run the game loop
			gameLoop.Start();
		}

		private enum RenderLayers
		{
			World
		}
	}
}