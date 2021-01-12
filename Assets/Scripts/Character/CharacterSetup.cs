using System;
using Character.SetupData;
using Character.Teddy;
using UnityEngine;

namespace Character
{
	[CreateAssetMenu(fileName = "CharacterSetup", menuName = "ScriptableObjects/CharacterSetup")]
	public class CharacterSetup : ScriptableObject
	{
		public FsmSetup fsmSetup;
		public MovementSetupBase MovementSetup;
		public AnimatorSetup AnimatorSetup;
	}
}