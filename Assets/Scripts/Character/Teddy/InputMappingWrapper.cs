using System;
using Cinemachine;
using Input;
using UnityEngine;

namespace Character.Teddy
{
	
	public class InputMappingWrapper
	{

		private static InputMapping inputMappingCache;

		public static InputMapping InputMapping { get; private set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitInput()
		{
			CinemachineCore.GetInputAxis = GetInputAxis; 
			
			Debug.Log($"<color=white>init input</color>");
			InputMapping = new InputMapping();
			InputMapping.Player.Enable();
			InputMapping.UI.Disable();
		}

		private static float GetInputAxis(string axisname)
		{
			// var xd = InputMapping.Player.Look.ReadValue<Vector2>();
			// Debug.Log($"<color=white>get input axis {axisname}, val = {xd}</color>");

			return 0f;
		}

		private void OnEnable()
		{
			InputMapping = new InputMapping();
		}

		private static void EnablePlayerMapping(InputMapping InputMapping)
		{
			InputMapping.Player.Enable();
			InputMapping.UI.Disable();
		}
	}
}