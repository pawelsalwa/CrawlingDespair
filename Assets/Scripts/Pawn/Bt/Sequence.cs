using System.Collections.Generic;

namespace Pawn.Bt
{
	public class Sequence : Node // evaluates nodes from left to right, failure if any failed
	{
		protected List<Node> nodes = new List<Node>();

		public Sequence(List<Node> nodes)
		{
			this.nodes = nodes;
		}
		public override NodeState Evaluate(Input input)
		{
			var isAnyNodeRunning = false;
			foreach (var node in nodes)
			{
				switch (node.Evaluate(input))
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