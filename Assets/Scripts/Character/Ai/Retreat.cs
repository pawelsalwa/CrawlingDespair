using Pawn;
using UnityEngine;

namespace Character.Ai
{
	public class Retreat : Node // gets back to strafe distance
	{
		public Retreat(Blackboard bb) : base(bb)
		{
		}

		public override NodeState Evaluate(PlayerInput playerInput)
		{
			playerInput.Movement = Vector2.down; // go backward
			return NodeState.Success;
		}
	}
}