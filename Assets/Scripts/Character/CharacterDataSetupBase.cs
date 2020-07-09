using Character.Teddy;
using UnityEngine;

namespace Character
{
	public class CharacterDataSetupBase : ScriptableObject
	{
		public IntRef TeddyHealth;
		public IntRef TeddyMaxHealth;
		public TeddyStateMachineSetup TeddyStateMachineSetup;
	}
}