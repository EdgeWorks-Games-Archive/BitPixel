using System;
using System.Diagnostics;
using System.Threading;

namespace BitPixel.Core
{
	public sealed class GameEngine : IDisposable
	{
		private bool _keepRunning;

		public bool IsRunning { get; private set; }

		public void Dispose()
		{
		}

		public void AddComponent(IEngineComponent component)
		{
			throw new NotImplementedException();
		}

		public void Start()
		{
			Debug.Assert(!IsRunning);
			Trace.TraceInformation("Starting game loop...");

			IsRunning = true;
			_keepRunning = true;
			while (_keepRunning)
			{
				Thread.Sleep(16);
				Stop();
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