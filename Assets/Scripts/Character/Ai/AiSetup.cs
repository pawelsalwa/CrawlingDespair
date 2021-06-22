using UnityEngine;

namespace Character.Ai
{

	[CreateAssetMenu(fileName = "AiSetup", menuName = "ScriptableObjects/AiSetup")]
	public class AiSetup : ScriptableObject
	{
		public float sightRange = 10f;
		public LayerMask playerLayerMask;
		public float attRange = 1f;
		public float attackCooldownTime = 3f;
	}
}