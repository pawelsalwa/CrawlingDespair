using Pawn;
using UnityEngine;

namespace Character.Ai
{
	public class Aggro : Selector
	{
		public Aggro(Blackboard bb) : base(bb)
		{
			var attack = new Attack(bb);
			var chase = new Chase(bb);
			var retreat = new Retreat(bb);
			// var strafe = new Strafe(bb);
			
			children.Add(attack);
			children.Add(chase);
			children.Add(retreat);
			// children.Add(strafe);
		}

		public override NodeState Evaluate(PlayerInput playerInput)
		{
			bb.currentNodeDebug = this;
			if (!bb.DoesSeeTarget())
				return NodeState.Failure; // nie wiem czy selector powinien miec logike ale huj, narazie niech bedzie tu rozroznienie na aggro & idle
			playerInput.LookAtAngle = GetLookAtTargetRotation(); // ten selector patrzy na target i tyle. taki tam dekorator to chyba sie nazywa
			return base.Evaluate(playerInput);
		}

		private float GetLookAtTargetRotation()
		{
			var dir = bb.Target.transform.position - bb.transform.position;
			return Quaternion.LookRotation(dir, Vector3.up).eulerAngles.y;
		}
	}
}