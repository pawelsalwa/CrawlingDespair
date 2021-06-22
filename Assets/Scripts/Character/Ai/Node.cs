	
using System.Collections.Generic;
using Pawn;

namespace Character.Ai
{
	
	public abstract class Node
	{
		public List<Node> children = new List<Node>();
		
		protected Blackboard bb;
		protected AiSetup setup;

		protected Node(Blackboard bb)
		{
			this.bb = bb;
			setup = bb.setup;
		}
		
		protected NodeState state;

		public abstract NodeState Evaluate(PlayerInput playerInput);
	}

	public enum NodeState
	{
		Running, Success, Failure,
	}
}