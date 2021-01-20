using GameCore;
using UnityEngine;

namespace Pawn.Bt
{
	public class Chase : Node
	{
		private readonly AiSetup aiSetup;
		private Transform transform;
		private Pawn target = null;

		public Chase(AiSetup aiSetup, Transform transform)
		{
			this.aiSetup = aiSetup;
			this.transform = transform;
			TrySetTarget(); // why not at start
		}
		
		public override NodeState Evaluate(Input input)
		{
			if (!DoesSeeTarget()) return NodeState.Failure;
			
			var dir = target.transform.position - transform.position;
			var dir2 = new Vector2(dir.x ,dir.z);

			// input.ResetFields();
			input.LookAtAngle = Vector2.Angle(Vector2.right, dir2);
			
			return DoesSeeTarget() ? NodeState.Success : NodeState.Failure;
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