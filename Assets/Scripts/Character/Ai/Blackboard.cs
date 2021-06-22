using GameCore;
using UnityEngine;

namespace Character.Ai
{
	/// <summary> runtime data used by ai </summary>
	public class Blackboard
	{
		public AiSetup setup; // exception - immutable data used by ai
		public Transform transform;

		private Character _target;
		public Node currentNodeDebug;

		public Blackboard(AiSetup setup)
		{
			this.setup = setup;
		}

		public Character Target
		{
			get
			{
				if (_target != null) return _target;
				var go = GameObject.FindGameObjectWithTag(GameStatics.PlayerTag);
				_target = go.GetComponent<Character>();
				return Target;
			}
		}

		public bool DoesSeeTarget()
		{
			if (Target == null) return false;
			var pos = transform.position + Vector3.up * 1.8f;
			var ray = new Ray(pos, Target.transform.position - pos);
			// Debug.DrawRay(ray.origin, Target.transform.position - pos, Color.blue, 1f);
			// var succ = Physics.Raycast(ray, setup.sightRange, setup.playerLayerMask);
			// succ = succ && DistToTarget < setup.sightRange;
			return DistToTarget < setup.sightRange; // cos kurwa nei dzial raycast, nie chce mi sie z tym jebac narazie
		}

		public bool IsInFightRange()
		{
			if (Target == null) return false;
			return DistToTarget < setup.attRange;
		}

		public float DistToTarget => Target == null ? float.PositiveInfinity : (_target.transform.position - transform.position).magnitude;
	}
}