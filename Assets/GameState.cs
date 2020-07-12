using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
	[CreateAssetMenu(fileName = "GameState", menuName = "ScriptableObjects/GameState")]
	public class GameState : ScriptableObject
	{

		private event Action<GameStateType> OnStateChanged;

		private GameStateType currentState = GameStateType.None;

		public void SubscribeToChange(Action<GameStateType> action) => OnStateChanged += action;
		public void UnsubscribeFromChange(Action<GameStateType> action) => OnStateChanged -= action;

		public void ChangeGameState(GameStateType newState)
		{
			currentState = newState;

			if (currentState == GameStateType.Exploration) UnpauseGame();
			if (currentState != GameStateType.Paused) PauseGame();
			OnStateChanged?.Invoke(newState);
		}

		public void TogglePause()
		{
			if (currentState == GameStateType.Exploration) ChangeGameState(GameStateType.Paused);
			if (currentState == GameStateType.Paused) ChangeGameState(GameStateType.Exploration);
		}

		[ContextMenu("PauseGame")]
		private void PauseGame()
		{
			// Time.timeScale = 0f;
			Cursor.lockState = CursorLockMode.None;
		}

		[ContextMenu("UnpauseGame")]

		private void UnpauseGame()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}

		private void OnEnable()
		{
			ChangeGameState(GameStateType.Exploration);
		}
	}

	public enum GameStateType
	{
		Exploration,
		Paused,
		None
	}
}