using Pawn;
using UnityEngine;

namespace Character.Ai
{
	public class Chase : Node
	{
		public Chase(Blackboard bb) : base(bb)
		{
		}

		public override NodeState Evaluate(PlayerInput playerInput)
		{
			playerInput.Movement = Vector2.up; // go forward
			return NodeState.Success;
		}
	}
}