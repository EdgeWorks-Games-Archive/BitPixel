using OpenTK;

namespace BitPixel.Graphics
{
	public class RenderContext
	{
		public Matrix4 ProjectionMatrix { get; set; }
		public Vector2 ModelViewOffset { get; set; }
	}
}