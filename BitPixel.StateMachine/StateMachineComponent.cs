using System;
using System.Collections.Generic;

namespace BitPixel.StateMachine
{
	public sealed class StateMachineComponent : IEngineComponent
	{
		private readonly IDictionary<IGameState, IStateConfiguration> _states =
			new Dictionary<IGameState, IStateConfiguration>();

		public IGameState InitialState { get; set; }

		public void Update(TimeSpan delta)
		{
		}

		public StateConfiguration<TEvents> AddState<TState, TEvents>(TState state)
		{
			return new StateConfiguration<TEvents>();
		}
	}
}