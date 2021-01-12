#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace Tools
{
	public static class SalwaEditorShortcuts
	{

		[Shortcut("SalwaClearConsole", KeyCode.X)]
		private static void SalwaClearConsole()
		{
			CleanUnityConsole();
		}
		
		private static void CleanUnityConsole()
		{
			var assembly = Assembly.GetAssembly(typeof(SceneView));
			var type = assembly.GetType("UnityEditor.LogEntries");
			var method = type.GetMethod("Clear");
			method.Invoke(new object(), null);
		}
	}
}
#endif