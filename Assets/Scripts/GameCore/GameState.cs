using System;
using UnityEngine;

namespace GameCore
{
	
	public static class GameState
	{

		public static event Action<GameStateType> OnStateChanged;

		private static GameStateType currentState = GameStateType.None;

		public static void ChangeState(GameStateType newState)
		{
			currentState = newState;
			OnStateChanged?.Invoke(newState);
		}

		// public void ChangeGameState(GameStateType newState)
		// {
		// 	currentState = newState;
		//
		// 	if (currentState == GameStateType.Exploration) UnpauseGame();
		// 	if (currentState != GameStateType.Paused) PauseGame();
		// 	OnStateChanged?.Invoke(newState);
		// }
		//
		// public void TogglePause()
		// {
		// 	if (currentState == GameStateType.Exploration) ChangeGameState(GameStateType.Paused);
		// 	if (currentState == GameStateType.Paused) ChangeGameState(GameStateType.Exploration);
		// }

		// [ContextMenu("PauseGame")]
		// private void PauseGame()
		// {
		// 	// Time.timeScale = 0f;
		// 	Cursor.lockState = CursorLockMode.None;
		// }
		//
		// [ContextMenu("UnpauseGame")]
		//
		// private void UnpauseGame()
		// {
		// 	Cursor.lockState = CursorLockMode.Locked;
		// }
	}

	public enum GameStateType
	{
		None,
		InGame,
		InGameMenu,
	}
}