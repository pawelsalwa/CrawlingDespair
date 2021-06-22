#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tools
{
	/// <summary> Collection of project editor shortcuts. Lots of these might be useless x) </summary>
	public static class EditorShortcuts
	{
		[UnityEditor.ShortcutManagement.Shortcut("Clear Console", KeyCode.X)]
		private static void ClearUnityConsole() // when game window is focused this will not work :( we need to call this from some update too
			=> ClearConsoleTool.ClearUnityConsole();

		[UnityEditor.ShortcutManagement.Shortcut("RequestScriptCompilation", KeyCode.Y)]
		private static void RequestScriptCompilation()
		{
			Debug.Log("<color=white>you pressed y shortcut, recompliing scripts...</color>");
			UnityEditor.Compilation.CompilationPipeline.RequestScriptCompilation();
		}

		[UnityEditor.ShortcutManagement.Shortcut("Toggle GO Active", KeyCode.F12)]
		private static void ToggleGoActivationShortcut()
		{
			bool toggleOn = !Selection.gameObjects.Any(x => x.activeSelf);
			foreach (var obj in Selection.gameObjects)
			{
				obj.SetActive(toggleOn);
				EditorUtility.SetDirty(obj);
			}
		}

		private static IEnumerable<T> FindInactiveComponents<T>() where T : Component // theres no method in unity api that search through all inactive components
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
				foreach (var obj in SceneManager.GetSceneAt(i).GetRootGameObjects())
					foreach (var component in obj.GetComponentsInChildren<T>(true))
						yield return component;
		}
	}
}
#endif