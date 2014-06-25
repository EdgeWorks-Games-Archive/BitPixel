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

#if DEBUG
			using (var game = new Game())
			{
				game.Run();
			}
#else
			try
			{
				using (var game = new Game())
				{
					game.Run();
				}
			}
			catch (Exception e)
			{
				Trace.TraceError(" ==== Start of Exception Report ==== ");

				Trace.TraceError(e.ToString());

				Trace.TraceError(" ==== End of Exception Report ==== ");
				Trace.WriteLine("");
				Trace.Flush();

				throw;
			}
#endif

			var endTime = DateTime.Now;
			Trace.TraceInformation(" ==== End of Execution {0} ==== ", endTime.ToString("O"));
			Trace.TraceInformation("Execution duration: {0}", endTime - startTime);
			Trace.WriteLine("");
			Trace.Flush();
		}
	}
}