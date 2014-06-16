using System;
using System.Diagnostics;

namespace BitPixel
{
	public sealed class GameLoop
	{
		private bool _keepRunning;

		public bool IsRunning { get; private set; }
		public TimeSpan TargetFrameDelta { get; set; }

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
}