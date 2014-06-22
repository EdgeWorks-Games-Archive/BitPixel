using System;
using System.Diagnostics;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace BitPixel
{
	public sealed class GameWindow
	{
		private readonly OpenTK.GameWindow _gameWindow = new OpenTK.GameWindow(1280, 720, GraphicsMode.Default, "BitPixel");

		public GameWindow()
		{
			_gameWindow.WindowBorder = WindowBorder.Fixed;
			_gameWindow.UpdateFrame += (s, e) => Update(this, new GameLoopEventArgs(TimeSpan.FromSeconds(e.Time)));
			_gameWindow.RenderFrame += OnRender;
		}

		void OnRender(object sender, OpenTK.FrameEventArgs e)
		{
			var time = TimeSpan.FromSeconds(e.Time);

			GL.ClearColor(Color.Black);
			GL.Clear(ClearBufferMask.ColorBufferBit);

			Render(this, new GameLoopEventArgs(time));

			_gameWindow.SwapBuffers();
		}

		public bool IsRunning { get; private set; }

		public event EventHandler<GameLoopEventArgs> Update = (s, a) => { };
		public event EventHandler<GameLoopEventArgs> Render = (s, a) => { };

		public void Start()
		{
			Debug.Assert(!IsRunning, "Cannot start if already started.");
			Trace.TraceInformation("Starting game loop...");

			IsRunning = true;

			_gameWindow.Run(60);

			IsRunning = false;

			Trace.TraceInformation("Game loop ended!");
		}

		public void Stop()
		{
			Debug.Assert(IsRunning);
			Trace.TraceInformation("Stop() called!");

			_gameWindow.Close();
		}
	}

	public sealed class GameLoopEventArgs : EventArgs
	{
		public GameLoopEventArgs(TimeSpan delta)
		{
			DeltaTime = delta;
		}

		public TimeSpan DeltaTime { get; private set; }
	}
}