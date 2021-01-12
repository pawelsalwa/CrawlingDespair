using UnityEngine;
using UnityEngine.Serialization;

namespace Character.Teddy
{
	[CreateAssetMenu(fileName = "TeddyDataSetup", menuName = "ScriptableObjects/TeddyDataSetup")]
	public class TeddySetup : CharacterSetup
	{
		public FsmSetup fsmSetup;
		public AnimatorSetup animatorSetup;
	}
}