using BitPixel.Graphics;

namespace BitPixel.World
{
	public interface IWorldRenderer
	{
		void Render(Terrain terrain, RenderContext context);
	}
}