using System;
using OpenTK.Graphics.OpenGL4;

namespace BitPixel.Graphics
{
	public sealed class VertexBuffer : IDisposable
	{
		private readonly int _vertexBuffer;

		public VertexBuffer(float[] data)
		{
			// Create the new buffer
			_vertexBuffer = GL.GenBuffer();

			// Bind it and set the data
			GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBuffer);
			GL.BufferData(
				BufferTarget.ArrayBuffer,
				new IntPtr(sizeof(float) * data.Length), data,
				BufferUsageHint.DynamicDraw);
			// TODO: Allow different usage hints.
			// DynamicDraw is draw a few times.
			// StaticDraw is draw a lot of times.

			// Clean up
			GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
		}

		~VertexBuffer()
		{
			Dispose();
		}

		public void Dispose()
		{
			GL.DeleteBuffer(_vertexBuffer);
			GC.SuppressFinalize(this);
		}

		public void Bind()
		{
			GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBuffer);
		}
	}
}
