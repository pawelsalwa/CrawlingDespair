	
namespace Pawn.Bt
{
	
	public abstract class Node
	{
		
		protected NodeState state;

		public abstract NodeState Evaluate(Input input);
	}

	public enum NodeState
	{
		Running, Success, Failure,
	}
}