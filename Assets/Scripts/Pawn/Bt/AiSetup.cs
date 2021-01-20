using UnityEngine;

namespace Pawn.Bt
{

	[CreateAssetMenu(fileName = "AiSetup", menuName = "ScriptableObjects/AiSetup")]
	public class AiSetup : ScriptableObject
	{
		public float sightRange = 10f;
		public LayerMask playerLayerMask;
	}
}