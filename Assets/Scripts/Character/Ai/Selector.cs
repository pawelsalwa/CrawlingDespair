using Pawn;

namespace Character.Ai
{
	public class Selector : Node // evaluates children from left to right, until one succeed 
	{

		public Selector(Blackboard bb) : base(bb)
		{
		}

		public override NodeState Evaluate(PlayerInput playerInput)
		{
			bb.currentNodeDebug = this;
			foreach (var node in children)
			{
				switch (node.Evaluate(playerInput))
				{
					case NodeState.Running: return NodeState.Running;
					case NodeState.Success: return NodeState.Success;
					case NodeState.Failure: state = NodeState.Failure; break;
				}
			}
			return state;
		}
	}
}