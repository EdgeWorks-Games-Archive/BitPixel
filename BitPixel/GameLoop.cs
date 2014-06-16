using System;
using System.Diagnostics;

namespace BitPixel
{
	public sealed class GameLoop
	{
		private bool _keepRunning;

		public bool IsRunning { get; private set; }

		public event EventHandler<GameLoopEventArgs> Update = (s, a) => { };
		public event EventHandler<GameLoopEventArgs> Render = (s, a) => { };

		public void Start()
		{
			Debug.Assert(!IsRunning, "Cannot start if already started.");
			Trace.TraceInformation("Starting game loop...");

			IsRunning = true;
			_keepRunning = true;
			while (_keepRunning)
			{
				Update(this, new GameLoopEventArgs(TimeSpan.FromMilliseconds(16)));
				Render(this, new GameLoopEventArgs(TimeSpan.FromMilliseconds(16)));
			}
			IsRunning = false;

			Trace.TraceInformation("Game loop ended!");
		}

		public void Stop()
		{
			Debug.Assert(IsRunning);
			Trace.TraceInformation("Stop() called!");

			_keepRunning = false;
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