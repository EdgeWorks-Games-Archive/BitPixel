using System;
using System.Diagnostics;

namespace BitPixel
{
	public sealed class GameEngine : IDisposable
	{
		private bool _keepRunning;

		public GameEngine()
		{
			Components = new EngineComponentCollection();
		}

		public bool IsRunning { get; private set; }
		public TimeSpan TargetFrameDelta { get; set; }
		public EngineComponentCollection Components { get; private set; }

		public void Dispose()
		{
		}

		public event EventHandler Update = (s, a) => { };
		public event EventHandler Render = (s, a) => { };

		public void Start()
		{
			Debug.Assert(!IsRunning, "Cannot start if already started.");
			Trace.TraceInformation("Starting game loop...");

			IsRunning = true;
			_keepRunning = true;
			while (_keepRunning)
			{
				Update(this, EventArgs.Empty);
				Render(this, EventArgs.Empty);
			}

			Trace.TraceInformation("Game loop ended!");
		}

		public void Stop()
		{
			Debug.Assert(IsRunning);
			Trace.TraceInformation("Stop() called!");

			_keepRunning = false;
		}
	}
}