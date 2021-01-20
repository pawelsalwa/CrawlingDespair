using UnityEngine;

namespace Pawn.Bt
{
	public class Bt
	{
		// private readonly AiSetup aiSetup;
		private readonly Node root;
		
		public Bt(AiSetup aiSetup, Transform transform)
		{
			// this.aiSetup = aiSetup;
			root = new Root(aiSetup, transform);
		}

		public void Update(Input input)
		{
			
			var result =  root.Evaluate(input);
			if (result == NodeState.Failure) Debug.Log($"<color=red> Root node returned failure. This means Ai Bug</color>");
		}
	}
}

