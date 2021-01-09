using Character.Teddy;
using GameCore;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class InGameMenu : UIBehaviour
	{
		
		private CanvasGroup _canvasGroup;
		private CanvasGroup canvasGroup => _canvasGroup ? _canvasGroup : _canvasGroup = GetComponent<CanvasGroup>();
		
		protected override void OnEnable()
		{
			InputMappingWrapper.InputMapping.Player.Esc.performed += PauseGame;
			InputMappingWrapper.InputMapping.UI.Esc.performed += UnpauseGame;
			UnpauseGame(default);
		}

		protected override void OnDisable()
		{
			InputMappingWrapper.InputMapping.Player.Esc.performed -= PauseGame;
			InputMappingWrapper.InputMapping.UI.Esc.performed -= UnpauseGame;
		}

		private void PauseGame(InputAction.CallbackContext obj) 
		{
			Time.timeScale = 0f;
			Cursor.lockState = CursorLockMode.None;
			canvasGroup.alpha = 1f;
			canvasGroup.interactable = true;
		}
		
		private void UnpauseGame(InputAction.CallbackContext obj)
		{
			Time.timeScale = 1f;
			Cursor.lockState = CursorLockMode.Locked;
			canvasGroup.alpha = 0f;
			canvasGroup.interactable = false;
		}
	}
}