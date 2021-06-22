using UnityEngine;

namespace Character.Setup
{
	[CreateAssetMenu(fileName = "PawnSetup", menuName = "ScriptableObjects/PawnSetup")]
	public class PawnSetup : ScriptableObject
	{
		public FsmSetup Fsm;
		public MovementSetup Movement;
		public AnimatorSetup Animator;
	}
}