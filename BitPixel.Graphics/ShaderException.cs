using System;
using System.Runtime.Serialization;

namespace BitPixel.Graphics
{
	public class ShaderException : Exception, ISerializable
	{
		public ShaderException(string message, string shaderLog)
			: base(message)
		{
			ShaderLog = shaderLog;
		}

		protected ShaderException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			ShaderLog = info.GetString("ShaderLog");
		}

		public string ShaderLog { get; private set; }

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			info.AddValue("ShaderLog", ShaderLog);
		}
	}
}