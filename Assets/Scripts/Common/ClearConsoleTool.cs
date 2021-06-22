using System.Reflection;

namespace Tools
{
	public static class ClearConsoleTool // todo move it to some global tools class
	{
		public static void ClearUnityConsole()
		{
#if UNITY_EDITOR
			var assembly = Assembly.GetAssembly(typeof(UnityEditor.SceneView));
			var type = assembly.GetType("UnityEditor.LogEntries");
			var method = type.GetMethod("Clear");
			method.Invoke(new object(), null);
#endif
		}

	}
}