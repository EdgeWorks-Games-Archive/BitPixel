using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace BitPixel
{
	public sealed class EngineComponentCollection : IEnumerable<EngineComponentBase>
	{
		private readonly List<EngineComponentBase> _components = new List<EngineComponentBase>();

		public IEnumerator<EngineComponentBase> GetEnumerator()
		{
			return _components.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(EngineComponentBase component)
		{
			Debug.Assert(!_components.Contains(component), "Cannot add already added component.");
			_components.Add(component);
		}

		public void Remove(EngineComponentBase component)
		{
			Debug.Assert(_components.Contains(component), "Cannot remove nonexistent component.");
			_components.Remove(component);
		}
	}
}