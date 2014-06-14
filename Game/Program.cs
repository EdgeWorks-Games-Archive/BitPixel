using BitPixel;
using BitPixel.StateMachine;
using Game.MainGame;
using Game.MainMenu;

namespace Game
{
	internal static class Program
	{
		private static void Main()
		{
			using (var engine = new GameEngine())
			{
				var stateMachine = new StateMachine();
				engine.AddComponent(stateMachine);

				var mainMenu = new MainMenuState();
				var mainGame = new MainGameState();

				var mainMenuConfig = stateMachine.AddState<MainMenuState, MainMenuEvents>(mainMenu);
				mainMenuConfig.AddTransition(MainMenuEvents.StartGame, mainGame);
				mainMenuConfig.AddExit(MainMenuEvents.Quit);

				var mainGameConfig = stateMachine.AddState<MainGameState, MainGameEvents>(mainGame);
				mainGameConfig.AddTransition(MainGameEvents.QuitToMenu, mainMenu);
				mainGameConfig.AddExit(MainGameEvents.QuitToDesktop);

				stateMachine.InitialState = mainMenu;

				engine.Start();
			}
		}
	}
}