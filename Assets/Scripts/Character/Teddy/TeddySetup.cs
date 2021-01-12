using UnityEngine;

namespace Character.Teddy
{
	[CreateAssetMenu(fileName = "TeddyDataSetup", menuName = "ScriptableObjects/TeddyDataSetup")]
	public class TeddySetup : CharacterSetup
	{
		public TeddyStateMachineSetup teddyFsmSetup;
		public TeddyAnimatorSetup TeddyAnimatorSetup;
	}
}