using System;
using System.Collections.Generic;
using BitPixel.Core;

namespace BitPixel.StateMachine
{
	public sealed class StateMachine : IEngineComponent
	{
		private IDictionary<Type, IStateConfiguration> _states = new Dictionary<Type, IStateConfiguration>();

		public StateConfiguration<TEvents> AddState<TState, TEvents>()
		{
			throw new NotImplementedException();
		}

		public void SetState<TState>()
		{
			throw new NotImplementedException();
		}
	}
}