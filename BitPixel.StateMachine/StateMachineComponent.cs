using System;
using System.Collections.Generic;

namespace BitPixel.StateMachine
{
	public sealed class StateMachineComponent : IEngineComponent
	{
		private readonly IDictionary<IGameState, IStateConfiguration> _states =
			new Dictionary<IGameState, IStateConfiguration>();

		public IGameState InitialState { get; set; }

		public void Update(float delta)
		{
			throw new NotImplementedException();
		}

		public StateConfiguration<TEvents> AddState<TState, TEvents>(TState state)
		{
			throw new NotImplementedException();
		}
	}
}