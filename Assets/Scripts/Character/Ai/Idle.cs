using Pawn;

namespace Character.Ai
{
	public class Idle : Node
	{

		public Idle(Blackboard bb) : base(bb)
		{
		}

		public override NodeState Evaluate(PlayerInput playerInput)
		{
			bb.currentNodeDebug = this;
			if (bb.DoesSeeTarget()) return NodeState.Failure;
			playerInput.ResetFields(); // na razie ma nic nie robic
			return NodeState.Success;
		}
	}
}