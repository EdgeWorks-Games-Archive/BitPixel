using OpenTK.Graphics.OpenGL;

namespace BitPixel.World.Graphics
{
	public class WorldRenderer : IWorldRenderer
	{
		public void RenderRectangle()
		{
		}

		public void Render(Terrain render)
		{
			GL.Begin(PrimitiveType.Triangles);

			GL.Color3(1.0, 0.0, 1.0);
			GL.Vertex2(0, 0.5);
			GL.Vertex2(-0.5, -0.5);
			GL.Vertex2(0.5, -0.5);

			GL.End();
		}
	}
}