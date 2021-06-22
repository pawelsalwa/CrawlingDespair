using Pawn;
using UnityEngine;

namespace Character.Ai
{
	public class Attack : Node
	{
		private float lastTimeAttacked;
		

		private bool AttackCooldowned => Time.time > lastTimeAttacked + setup.attackCooldownTime;
		
		public Attack(Blackboard bb) : base(bb)
		{
		}

		public override NodeState Evaluate(PlayerInput playerInput)
		{
			if (!bb.IsInFightRange()) return NodeState.Failure;
			if (!AttackCooldowned) return NodeState.Failure;
			playerInput.Attack = true;
			lastTimeAttacked = Time.time;
			return NodeState.Success;
		}

	}
}