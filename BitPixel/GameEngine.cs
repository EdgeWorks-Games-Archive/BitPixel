using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

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

		public void Start()
		{
			Debug.Assert(!IsRunning, "Cannot start if already started.");
			Trace.TraceInformation("Starting game loop...");

			IsRunning = true;
			_keepRunning = true;
			while (_keepRunning)
			{
				// Later on these will get sorted in the order they need to be executed in
				foreach (var task in Components.SelectMany(c => c.FrameTasks))
					task.Execute(TargetFrameDelta);
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