using Pawn.Setup;
using UnityEngine;

namespace Pawn
{
	[CreateAssetMenu(fileName = "PawnSetup", menuName = "ScriptableObjects/PawnSetup")]
	public class PawnSetup : ScriptableObject
	{
		public FsmSetup Fsm;
		public MovementSetup Movement;
		public AnimatorSetup Animator;
	}
}