using System;
using OpenTK.Graphics.OpenGL4;

namespace BitPixel.Graphics
{
	public sealed class ShaderProgram : IDisposable
	{
		private readonly int _programId;

		public ShaderProgram()
		{
			_programId = GL.CreateProgram();
		}

		public void Dispose()
		{
			GL.DeleteProgram(_programId);
		}

		public ShaderActivationLifetime Use()
		{
			return new ShaderActivationLifetime(_programId);
		}

		~ShaderProgram()
		{
			Dispose();
		}

		public sealed class ShaderActivationLifetime : IDisposable
		{
			internal ShaderActivationLifetime(int programId)
			{
				GL.UseProgram(programId);
			}

			public void Dispose()
			{
				GL.UseProgram(0);
			}
		}
	}
}