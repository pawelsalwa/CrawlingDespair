using System.Collections.Generic;

namespace Pawn.Bt
{
	public class Selector : Node // evaluates children from left to right, returns success if any successess 
	{
		protected readonly List<Node> nodes = new List<Node>();
		
		public override NodeState Evaluate(Input input)
		{
			foreach (var node in nodes)
			{
				switch (node.Evaluate(input))
				{
					case NodeState.Running:
						state = NodeState.Running;
						return state;
					case NodeState.Success:
						state = NodeState.Success;
						return state;
					case NodeState.Failure:
						break;
				}
			}
			state = NodeState.Failure;
			return state;
		}
	}
}