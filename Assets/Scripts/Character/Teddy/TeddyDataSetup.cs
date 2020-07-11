using Character.FSMSetupData;
using Character.SetupData;
using UnityEngine;

namespace Character.Teddy
{
	[CreateAssetMenu(fileName = "TeddyDataSetup", menuName = "ScriptableObjects/TeddyDataSetup")]
	public class TeddyDataSetup : CharacterDataSetupBase
	{
		public TeddyStateMachineSetup teddyFsmSetup;
		public MovementSetupBase MovementSetup;
		public TeddyAnimatorSetup TeddyAnimatorSetup;
	}
}