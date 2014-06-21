using System;
using System.Runtime.Serialization;

namespace BitPixel.Graphics
{
	public class ProgramException : Exception, ISerializable
	{
		public ProgramException(string message, string programLog)
			: base(message)
		{
			ProgramLog = programLog;
		}

		protected ProgramException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			ProgramLog = info.GetString("ProgramLog");
		}

		public string ProgramLog { get; private set; }

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			info.AddValue("ProgramLog", ProgramLog);
		}
	}
}