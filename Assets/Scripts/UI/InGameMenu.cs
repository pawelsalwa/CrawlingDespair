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
			canvasGroup.alpha = 1f;
			canvasGroup.interactable = true;
			InputMappingWrapper.EnableUiMapping();
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		
		private void UnpauseGame(InputAction.CallbackContext obj)
		{
			Time.timeScale = 1f;
			canvasGroup.alpha = 0f;
			canvasGroup.interactable = false;
			InputMappingWrapper.EnablePlayerMapping();
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		#if UNITY_EDITOR
		protected override void Start()
		{
			UnityEditor.EditorApplication.playmodeStateChanged += HandleOnPlayModeChanged; // todo wyjevbac to stad
		}

		private void HandleOnPlayModeChanged()
		{
			if (UnityEditor.EditorApplication.isPaused)
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}
		#endif

	}
}