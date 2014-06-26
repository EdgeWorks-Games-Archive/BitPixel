using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BitPixel.Graphics
{
	public class Camera
	{
		private float _height, _width, _ratio;

		public Camera(Size resolution, float height)
		{
			_ratio = (float)resolution.Width / resolution.Height;
			Height = height;
		}

		public float Height
		{
			get { return _height; }
			set
			{
				Debug.Assert(_ratio != 0);

				_height = value;
				_width = value * _ratio;
			}
		}

		public float Width { get { return _width; } }

		public Vector2 Position { get; set; }

		public RenderContext CreateContext()
		{
			return new RenderContext
			{
				ProjectionMatrix = Matrix4.CreateOrthographic(Width, Height, 1, -1),
				ModelViewOffset = -Position
			};
		}
	}
}