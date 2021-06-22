using UnityEngine;

namespace Common.ExtensionMethods
{
	public static class TransformExtensions
	{

		public static void DestroyChildren(this Transform transform)
		{
			for (int i = transform.childCount - 1; i >= 0; i--)
			{
				if (!transform.GetChild(i).gameObject.activeSelf) continue;
				#if UNITY_EDITOR
				if (UnityEditor.EditorApplication.isPlaying)
					Object.Destroy(transform.GetChild(i).gameObject);
				else
				#endif
					Object.DestroyImmediate(transform.GetChild(i).gameObject);
			}
		}
	}
}