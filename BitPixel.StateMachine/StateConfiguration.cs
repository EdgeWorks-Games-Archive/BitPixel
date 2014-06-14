namespace BitPixel.StateMachine
{
	internal interface IStateConfiguration
	{
	}

	public class StateConfiguration<TEvents> : IStateConfiguration
	{
		internal StateConfiguration()
		{
		}

		public void AddTransition(TEvents evt, IGameState state)
		{
			throw new System.NotImplementedException();
		}

		public void AddExit(TEvents evt)
		{
			throw new System.NotImplementedException();
		}
	}
}