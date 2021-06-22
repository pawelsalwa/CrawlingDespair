using UnityEngine;

namespace Common.Utility
{
	public static class GameUtility
	{

		private const string PersistentComponentsGameObjectName = "-- PersistentObjects --";
		private static GameObject persistentGoCache;
		private static GameObject persistentGo
		{
			get
			{
				return persistentGoCache == null ? persistentGoCache = new GameObject(PersistentComponentsGameObjectName) : persistentGoCache;
			}
		}


		public static void ExitGame() // todo show are u sure popup
		{
#if UNITY_EDITOR
			if (Application.isEditor)
				UnityEditor.EditorApplication.ExitPlaymode();
			else
#endif
				Application.Quit();
		}

		public static void CreatePersistentComponent<T>() where T : Component => Object.DontDestroyOnLoad(persistentGo.AddComponent<T>());

	}
}