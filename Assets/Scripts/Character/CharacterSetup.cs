using System;
using Character.SetupData;
using UnityEngine;

namespace Character
{
	[Serializable]
	public class CharacterSetup : ScriptableObject
	{
		public MovementSetupBase MovementSetup;
	}
}