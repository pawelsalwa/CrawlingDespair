using System;
using Input;
using UnityEngine;

namespace Character.Teddy
{
	[CreateAssetMenu(fileName = "InputMappingWrapper", menuName = "ScriptableObjects/InputMappingWrapper")]
	public class InputMappingWrapper : ScriptableObject
	{
		public InputMapping InputMapping { get; private set; }

		private void OnEnable()
		{
			InputMapping = new InputMapping();
			EnablePlayerMapping();
		}

		private void EnablePlayerMapping()
		{
			InputMapping.Player.Enable();
			InputMapping.UI.Disable();
		}
	}
}