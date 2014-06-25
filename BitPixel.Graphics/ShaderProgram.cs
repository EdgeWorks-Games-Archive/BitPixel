using System;
using System.Diagnostics;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace BitPixel.Graphics
{
	public sealed class ShaderProgram : IDisposable
	{
		private readonly int _program;
		private readonly int _projectionUniform, _modelViewUniform;

		public ShaderProgram(string vertSource, string fragSource)
		{
			_program = GL.CreateProgram();

			AttachShader(_program, vertSource, ShaderType.VertexShader);
			AttachShader(_program, fragSource, ShaderType.FragmentShader);

			GL.LinkProgram(_program);

			// Report any errors found
			int linkStatus;
			GL.GetProgram(_program, GetProgramParameterName.LinkStatus, out linkStatus);
			var log = GL.GetProgramInfoLog(_program);
			if (linkStatus != 1)
			{
				var message = string.Format("Shader program {0} failed to link!", _program);
				Trace.TraceError(message);
				throw new ProgramException(message, log);
			}

			// If there's anything in the log, it might be a warning
			if (log != "")
			{
				Trace.TraceWarning("Shader program {0} compiled with warnings:", _program);
				Trace.Indent();
				foreach (var logLine in log.Split('\n'))
				{
					Trace.TraceWarning(logLine);
				}
				Trace.Unindent();
			}

			// Set up shader uniforms
			_projectionUniform = GL.GetUniformLocation(_program, "ProjectionMatrix");
			_modelViewUniform = GL.GetUniformLocation(_program, "ModelViewOffset");

			if (_projectionUniform == -1 || _modelViewUniform == -1)
			{
				var message = string.Format("Shader program {0} does not contain required uniforms!", _program);
				Trace.TraceError(message);
				throw new ProgramException(message);
			}

			Trace.TraceInformation("Created new shader program {0}!", _program);
		}

		public Matrix4 ProjectionMatrix
		{
			set
			{
				GL.UniformMatrix4(_projectionUniform, false, ref value);
			}
		}

		public Vector2 ModelViewMatrix
		{
			set
			{
				GL.Uniform2(_modelViewUniform, ref value);
			}
		}

		public void Dispose()
		{
			GL.DeleteProgram(_program);
			GC.SuppressFinalize(this);
		}

		public void Use()
		{
			GL.UseProgram(_program);
		}

		~ShaderProgram()
		{
			Trace.TraceWarning("[RESOURCE LEAK] Shader finalizer invoked!");
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
				var message = string.Format("Shader {0} failed to compile!", shader);
				Trace.TraceWarning(message);
				throw new ShaderException(
					message,
					GL.GetShaderInfoLog(shader),
					source,
					type);
			}

			GL.AttachShader(program, shader);
		}
	}
}