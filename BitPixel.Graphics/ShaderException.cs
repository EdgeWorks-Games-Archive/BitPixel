using System;
using System.Runtime.Serialization;
using OpenTK.Graphics.OpenGL4;

namespace BitPixel.Graphics
{
	public class ShaderException : Exception, ISerializable
	{
		public ShaderException(string message, string shaderLog, string shaderSource, ShaderType shaderType)
			: base(message)
		{
			ShaderLog = shaderLog;
			ShaderSource = shaderSource;
			ShaderType = shaderType;
		}

		protected ShaderException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			ShaderLog = info.GetString("ShaderLog");
			ShaderSource = info.GetString("ShaderSource");
			ShaderType = (ShaderType) info.GetInt32("ShaderType");
		}

		public string ShaderLog { get; private set; }
		public string ShaderSource { get; private set; }
		public ShaderType ShaderType { get; private set; }

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			info.AddValue("ShaderLog", ShaderLog);
			info.AddValue("ShaderSource", ShaderSource);
			info.AddValue("ShaderType", (int) ShaderType);
		}
	}
}