using System;
using System.Diagnostics;
using OpenTK.Graphics;

namespace BitPixel
{
	public sealed class GameWindow
	{
		private readonly OpenTK.GameWindow _gameWindow = new OpenTK.GameWindow(1280, 720, GraphicsMode.Default, "BitPixel");

		public GameWindow()
		{
			_gameWindow.UpdateFrame += (s, e) => Update(this, new GameLoopEventArgs(TimeSpan.FromSeconds(e.Time)));
			_gameWindow.RenderFrame += OnRender;
		}

		void OnRender(object sender, OpenTK.FrameEventArgs e)
		{
			var time = TimeSpan.FromSeconds(e.Time);

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
			Delta = delta;
		}

		public TimeSpan Delta { get; private set; }
	}
}