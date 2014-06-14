using BitPixel.Core;
using BitPixel.StateMachine;
using Game.MainGame;
using Game.MainMenu;

namespace Game
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			using (var engine = new GameEngine())
			{
				var stateMachine = new StateMachine();
				engine.AddComponent(stateMachine);

				var mainMenuConfig = stateMachine.AddState<MainMenuState, MainMenuEvents>();
				mainMenuConfig.AddTransition<MainGameState>(MainMenuEvents.StartGame);
				mainMenuConfig.AddExit(MainMenuEvents.Quit);

				var mainGameConfig = stateMachine.AddState<MainGameState, MainGameEvents>();
				mainGameConfig.AddTransition<MainMenuState>(MainGameEvents.QuitToMenu);
				mainGameConfig.AddExit(MainGameEvents.QuitToDesktop);

				stateMachine.SetState<MainMenuState>();

				engine.Start();
			}
		}
	}
}