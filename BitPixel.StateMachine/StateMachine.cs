using System;
using System.Collections.Generic;
using BitPixel.Core;

namespace BitPixel.StateMachine
{
	public sealed class StateMachine : IEngineComponent
	{
		private readonly IDictionary<IGameState, IStateConfiguration> _states = new Dictionary<IGameState, IStateConfiguration>();

		public StateConfiguration<TEvents> AddState<TState, TEvents>(TState state)
		{
			throw new NotImplementedException();
		}

		public void SetState<TState>()
		{
			throw new NotImplementedException();
		}
	}
}