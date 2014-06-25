using System;
using System.Diagnostics;

namespace Game
{
	internal static class Program
	{
		private static void Main()
		{
			var startTime = DateTime.Now;
			Trace.TraceInformation(" ==== Start of Execution {0} ==== ", startTime.ToString("O"));

			using (var game = new Game())
			{
				game.Run();
			}

			var endTime = DateTime.Now;
			Trace.TraceInformation(" ==== End of Execution {0} ==== ", endTime.ToString("O"));
			Trace.TraceInformation("Execution duration: {0}", endTime - startTime);
			
			Trace.WriteLine("");
			Trace.Flush();
		}
	}
}