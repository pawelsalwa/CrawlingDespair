using UnityEngine;

namespace Tools
{
	public class GizmoSphereDrawer : MonoBehaviour
	{
		public float radius = 0.05f;
		public Color color = Color.yellow;
		public bool isWireframed = false;

		private void OnDrawGizmos()
		{
			Gizmos.color = color;
			if (!isWireframed)
			{
				Gizmos.DrawSphere(transform.position, radius);
			}
			else
			{
				Gizmos.DrawWireSphere(transform.position, radius);
			}
		}
	}
}