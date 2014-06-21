using System;
using OpenTK.Graphics.OpenGL4;

namespace BitPixel.Graphics
{
	public sealed class ShaderProgram : IDisposable
	{
		private readonly int _program;

		public ShaderProgram(string vertSource, string fragSource)
		{
			_program = GL.CreateProgram();

			AttachShader(_program, vertSource, ShaderType.VertexShader);
			AttachShader(_program, fragSource, ShaderType.FragmentShader);

			GL.LinkProgram(_program);

			int linkStatus;
			GL.GetProgram(_program, GetProgramParameterName.LinkStatus, out linkStatus);
			if (linkStatus != 1)
			{
				throw new ProgramException(
					"Shader Program failed to link!",
					GL.GetProgramInfoLog(_program));
			}
		}

		public void Dispose()
		{
			GL.DeleteProgram(_program);
			GC.SuppressFinalize(this);
		}

		public ShaderActivationLifetime Use()
		{
			return new ShaderActivationLifetime(_program);
		}

		~ShaderProgram()
		{
			Dispose();
		}

		private static void AttachShader(int program, string source, ShaderType type)
		{
			var shader = GL.CreateShader(type);

			GL.ShaderSource(shader, source);
			GL.CompileShader(shader);

			int compileStatus;
			GL.GetShader(shader, ShaderParameter.CompileStatus, out compileStatus);
			if (compileStatus != 1)
			{
				throw new ShaderException(
					"Shader failed to compile!",
					GL.GetShaderInfoLog(shader),
					source,
					type);
			}

			GL.AttachShader(program, shader);
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