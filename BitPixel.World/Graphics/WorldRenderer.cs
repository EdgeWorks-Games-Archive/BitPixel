using BitPixel.Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL;

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

			_shaderProgram.ProjectionMatrix =
				Matrix4.Identity*
				Matrix4.CreateOrthographic(80, 80*ratio, 1, -1)*
				Matrix4.CreateTranslation(-40, -40, 0);
			_shaderProgram.ModelViewMatrix =
				Matrix4.Identity*
				Matrix4.CreateTranslation(-50, -20, 0);

			GL.Color3(1.0, 1.0, 1.0);
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
			GL.End();
		}
	}
}