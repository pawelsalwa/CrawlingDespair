using UnityEngine;

namespace Tools
{
	public class EnableDebugger : MonoBehaviour
	{
		private void OnEnable()
		{
			Debug.Log($"<color=green> enabled {gameObject.name}</color>", gameObject);
		}

		private void OnDisable()
		{
			Debug.Log($"<color=red> disabled {gameObject.name}</color>", gameObject);
		}
	}
}