using System;
using System.IO;
using BitPixel;
using BitPixel.Graphics;
using BitPixel.World;
using BitPixel.World.Graphics;
using OpenTK;

namespace Game
{
	internal class Game : IDisposable
	{
		private readonly BitPixelWindow _window;
		private readonly WorldRenderer _renderer;
		private readonly Camera _camera;

		private readonly ShaderProgram _shaderProgram;
		private readonly World _world;

		public Game()
		{
			// Set up the game loop
			_window = new BitPixelWindow();
			_window.Update += OnUpdate;
			_window.Render += OnRender;

			// Set up the rendering data
			_shaderProgram = new ShaderProgram(
				File.ReadAllText("./Shaders/basic.vert.glsl"),
				File.ReadAllText("./Shaders/color.frag.glsl"));
			_renderer = new WorldRenderer(_shaderProgram);
			_camera = new Camera(_window.Resolution, 40)
			{
				Position = new Vector2(50, 20)
			};

			// Set up a test world
			_world = new World();
		}

		public void Dispose()
		{
			_shaderProgram.Dispose();
			_renderer.Dispose();
		}

		void OnUpdate(object sender, GameLoopEventArgs e)
		{
		}

		private void OnRender(object sender, GameLoopEventArgs e)
		{
			var renderContext = _camera.CreateContext();
			_world.Render(_renderer, renderContext);
		}

		public void Run()
		{
			// Run the game loop
			_window.Start();
		}
	}
}