
using UnityEngine;

namespace Pawn.Bt
{
	public class Root : Selector
	{
		public Root(AiSetup aiSetup, Transform transform)
		{
			Node idle = new Idle(aiSetup, transform);
			Node chase = new Chase(aiSetup, transform);
			
			nodes.Add(idle);
			nodes.Add(chase);
		}
	}
}