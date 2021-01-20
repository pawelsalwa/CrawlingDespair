using GameCore;
using UnityEngine;

namespace Pawn.Bt
{
	public class Idle : Node
	{
		private readonly AiSetup aiSetup;
		private Transform transform;
		private Pawn target = null;

		public Idle(AiSetup aiSetup, Transform transform)
		{
			this.aiSetup = aiSetup;
			this.transform = transform;
			TrySetTarget(); // why not at start
		}

		public override NodeState Evaluate(Input input)
		{
			input.ResetFields(); // na razie ma nic nie robic
			return DoesSeeTarget() ? NodeState.Failure : NodeState.Success;
		}

		private void TrySetTarget()
		{
			if (target != null) return;
			var go = GameObject.FindGameObjectWithTag(GameStatics.PlayerTag);
			target = go.GetComponent<Pawn>();
		}

		private bool DoesSeeTarget()
		{
			TrySetTarget();
			if (target != null) return true;
			var pos = transform.position;
			var ray = new Ray(pos, target.transform.position - pos);
			var succ = Physics.Raycast(ray, aiSetup.sightRange, aiSetup.playerLayerMask);
			// var succ = Physics.Raycast(ray, out var result, aiSetup.sightRange, aiSetup.playerLayerMask);
			return succ;
		}
	}
}