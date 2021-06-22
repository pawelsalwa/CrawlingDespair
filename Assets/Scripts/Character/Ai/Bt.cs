using Pawn;
using UnityEngine;

namespace Character.Ai
{
	[CreateAssetMenu(fileName = "BehaviorTree", menuName = "ScriptableObjects/BehaviorTree")]
	public class Bt : ScriptableObject
	{
		public readonly Node root;
		public Blackboard blackboard;
		public AiSetup aiSetup;
		
		public Bt() // todo should be move d to onenable():??
		{
			root = new Root(new Blackboard(aiSetup));
		}

		public void Init(Transform transform)
		{
			blackboard.transform = transform;
		}

		public void UpdateInput(PlayerInput playerInput)
		{
			var result =  root.Evaluate(playerInput);
			// if (result == NodeState.Failure) Debug.Log($"<color=red> Root node returned failure. This means Ai Bug</color>");
		}
	}
}

