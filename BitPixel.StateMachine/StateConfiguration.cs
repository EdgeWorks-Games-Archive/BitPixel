namespace BitPixel.StateMachine
{
	internal interface IStateConfiguration
	{
	}

	public class StateConfiguration<TEvents> : IStateConfiguration
	{
		public void AddTransition<TState>(TEvents evt)
		{
			throw new System.NotImplementedException();
		}

		public void AddExit(TEvents evt)
		{
			throw new System.NotImplementedException();
		}
	}
}