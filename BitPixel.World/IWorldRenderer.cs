using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitPixel.World
{
	public interface IWorldRenderer
	{
		void Render(Terrain terrain);
	}
}
