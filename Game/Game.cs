using System;
using System.IO;
using BitPixel;
using BitPixel.Graphics;
using BitPixel.World;
using BitPixel.World.Graphics;

namespace Game
{
	internal class Game : IDisposable
	{
		private readonly GameWindow _gameWindow;
		private readonly WorldRenderer _renderer;

		private readonly ShaderProgram _shaderProgram;
		private readonly World _world;

		public Game()
		{
			// Set up the game loop
			_gameWindow = new GameWindow();
			_gameWindow.Render += OnRender;

			// Set up the rendering data
			_shaderProgram = new ShaderProgram(
				"void main() { gl_Position = gl_Vertex; }",
				File.ReadAllText("./Shaders/white.frag.glsl"));
			_renderer = new WorldRenderer(_shaderProgram);

			// Set up a test world
			_world = new World();
		}

		public void Dispose()
		{
			_shaderProgram.Dispose();
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