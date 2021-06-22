using System.Collections.Generic;
using Pawn;

namespace Character.Ai
{
	public class Sequence : Node // evaluates nodes from left to right, failure if any failed
	{
		protected List<Node> nodes;

		public Sequence(Blackboard bb, List<Node> nodes) : base(bb)
		{
			this.nodes = nodes;
		}
		
		public override NodeState Evaluate(PlayerInput playerInput)
		{
			bb.currentNodeDebug = this;
			var isAnyNodeRunning = false;
			foreach (var node in nodes)
			{
				switch (node.Evaluate(playerInput))
				{
					case NodeState.Running: isAnyNodeRunning = true; break;
					case NodeState.Success: break;
					case NodeState.Failure: state = NodeState.Failure; return state;
				}
			}
			state = isAnyNodeRunning ? NodeState.Running : NodeState.Success;
			return state;
		}
	}
}