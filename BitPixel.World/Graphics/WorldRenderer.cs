using System;
using BitPixel.Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace BitPixel.World.Graphics
{
	public class WorldRenderer : IWorldRenderer
	{
		private readonly ShaderProgram _shaderProgram;

		public WorldRenderer(ShaderProgram shaderProgram)
		{
			_shaderProgram = shaderProgram;
		}

		public void Render(Terrain terrain)
		{
			_shaderProgram.Use();

			const float ratio = 720.0f/1280.0f;

			_shaderProgram.ProjectionMatrix = Matrix4.CreateOrthographic(80, 80*ratio, 1, -1);
			_shaderProgram.ModelViewMatrix = Matrix4.Identity;

			const int quadMemSize = 2*3*2; // 2 values per vertex, 3 vertices per triangle, 2 triangles per quad
			var vertexData = new float[terrain.TerrainSegments.Count * quadMemSize];

			var x = 0;
			foreach (var segment in terrain.TerrainSegments)
			{
				var arrayOffset = x*quadMemSize;

				// Triangle 1
				//  /|
				// /_|
				vertexData[arrayOffset] = x;
				vertexData[arrayOffset + 1] = 0;

				vertexData[arrayOffset + 2] = x + 1;
				vertexData[arrayOffset + 3] = 0;

				vertexData[arrayOffset + 4] = x + 1;
				vertexData[arrayOffset + 5] = segment.Height;

				// Triangle 2
				// | /
				// |/
				vertexData[arrayOffset + 6] = x;
				vertexData[arrayOffset + 7] = 0;

				vertexData[arrayOffset + 8] = x + 1;
				vertexData[arrayOffset + 9] = segment.Height;

				vertexData[arrayOffset + 10] = x;
				vertexData[arrayOffset + 11] = segment.Height;

				x++;
			}

			using (var vertexBuffer = new VertexBuffer(vertexData))
			{
				// Enable the attribute arrays so we can send attributes
				// TODO: Improve the entire system of sending vertex attributes so it's a lot safer
				GL.EnableVertexAttribArray(0);

				vertexBuffer.Bind();

				// Set the position attribute pointer
				GL.VertexAttribPointer(
					0, // Location
					2, // Size
					VertexAttribPointerType.Float, // Type
					false, // Normalized
					2*sizeof (float), // Offset between values
					0); // Start offset

				// And finally, draw
				GL.DrawArrays(PrimitiveType.Triangles, 0, vertexData.Length);

				// Clean up
				GL.DisableVertexAttribArray(0);
			}
		}
	}
}