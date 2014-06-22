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

			var vertexData = new[]
			{
				// position
				-1f, -1f,
				1f, -1f,
				-1f, 1f,
			};

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
				GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

				// Clean up
				GL.DisableVertexAttribArray(0);
			}

			/*GL.Color3(1.0, 1.0, 1.0);
			GL.Begin(PrimitiveType.Quads);
			var x = 0;
			foreach (var segment in terrain.TerrainSegments)
			{
				GL.Vertex2(x, 0);
				GL.Vertex2(x + 1, 0);
				GL.Vertex2(x + 1, segment.Height);
				GL.Vertex2(x, segment.Height);

				x++;
			}
			GL.End();*/
		}
	}
}