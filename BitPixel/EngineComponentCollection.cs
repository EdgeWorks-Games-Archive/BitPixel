using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace BitPixel
{
	public sealed class EngineComponentCollection : IEnumerable<IEngineComponent>
	{
		private readonly List<IEngineComponent> _components = new List<IEngineComponent>();

		public IEnumerator<IEngineComponent> GetEnumerator()
		{
			return _components.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(IEngineComponent component)
		{
			Debug.Assert(!_components.Contains(component), "Cannot add already added component.");
			_components.Add(component);
		}

		public void Remove(IEngineComponent component)
		{
			Debug.Assert(_components.Contains(component), "Cannot remove nonexistent component.");
			_components.Remove(component);
		}
	}
}