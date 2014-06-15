using System;
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
				// Set engine settings
				engine.TargetDelta = TimeSpan.FromSeconds(1/60f);

				// Initialize state machine component
				var stateMachine = new StateMachineComponent();
				engine.AddComponent(stateMachine);

				// Create states
				var mainMenu = new MainMenuState();
				var mainGame = new MainGameState();

				// Configure states in state machine
				var mainMenuConfig = stateMachine.AddState<MainMenuState, MainMenuEvents>(mainMenu);
				mainMenuConfig.AddTransition(MainMenuEvents.StartGame, mainGame);
				mainMenuConfig.AddExit(MainMenuEvents.Quit);

				var mainGameConfig = stateMachine.AddState<MainGameState, MainGameEvents>(mainGame);
				mainGameConfig.AddTransition(MainGameEvents.QuitToMenu, mainMenu);
				mainGameConfig.AddExit(MainGameEvents.QuitToDesktop);

				stateMachine.InitialState = mainMenu;

				// Actually run the engine
				engine.Start();
			}
		}
	}
}