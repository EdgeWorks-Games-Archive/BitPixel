using BitPixel.World;
using OpenTK.Graphics.OpenGL;

namespace BitPixel.Graphics.Renderers
{
	public class WorldRenderer : IWorldRenderer
	{
		public void Render(Terrain terrain)
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
