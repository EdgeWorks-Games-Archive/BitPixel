using System;
using System.Diagnostics;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace BitPixel.Graphics
{
	public sealed class VertexBuffer : IDisposable
	{
		private readonly int _vertexBuffer;
		private readonly BufferUsageHint _usageHint;

		public VertexBuffer(BufferUsageHint usageHint)
		{
			// Create the new buffer
			_vertexBuffer = GL.GenBuffer();

			_usageHint = usageHint;
		}

		public VertexBuffer(BufferUsageHint usageHint, Vector2[] data)
			: this(usageHint)
		{
			UpdateData(data);
		}

		~VertexBuffer()
		{
			Trace.TraceWarning("[RESOURCE LEAK] Vertex buffer finalizer invoked!");
			Dispose();
		}

		public void UpdateData(Vector2[] data)
		{
			// TODO: Make updating data part of a usage lifetime object
			// Bind it and set the data
			GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBuffer);
			GL.BufferData(
				BufferTarget.ArrayBuffer,
				new IntPtr(Vector2.SizeInBytes * data.Length), data,
				_usageHint);
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
