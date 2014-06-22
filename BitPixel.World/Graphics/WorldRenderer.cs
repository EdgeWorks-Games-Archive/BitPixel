using System;
using System.Diagnostics;
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
			_shaderProgram.ModelViewMatrix = Matrix4.Identity * Matrix4.CreateTranslation(-40, -20, 0);

			const int quadMemSize = 3*2; // 3 vertices per triangle, 2 triangles per quad
			var vertexData = new Vector2[terrain.TerrainSegments.Count * quadMemSize];
			
			var x = 0;
			foreach (var segment in terrain.TerrainSegments)
			{
				var arrayOffset = x*quadMemSize;

				// Triangle 1
				//  /|
				// /_|
				vertexData[arrayOffset + 0] = new Vector2(x, 0);
				vertexData[arrayOffset + 1] = new Vector2(x + 1, 0);
				vertexData[arrayOffset + 2] = new Vector2(x + 1, segment.Height);

				// Triangle 2
				// | /
				// |/
				vertexData[arrayOffset + 3] = new Vector2(x, 0);
				vertexData[arrayOffset + 4] = new Vector2(x + 1, segment.Height);
				vertexData[arrayOffset + 5] = new Vector2(x, segment.Height);

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
					Vector2.SizeInBytes, // Offset between values
					0); // Start offset

				// And finally, draw
				GL.DrawArrays(PrimitiveType.Triangles, 0, vertexData.Length);

				// Clean up
				GL.DisableVertexAttribArray(0);
			}
		}
	}
}