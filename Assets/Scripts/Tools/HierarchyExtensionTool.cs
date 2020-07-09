#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEditor.Experimental.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tools
{
	public static class HierarchyExtensionTool
	{
		private static bool colorThis = false;
		private static bool toolActive = false;

		private const string ToolActivePropertyName = "HierarchyExtensionTool.toolActive";

		[InitializeOnLoadMethod]
		public static void Method()
		{
			EditorApplication.hierarchyWindowItemOnGUI -= OnHierarchyItemDrawWrapper;
			EditorApplication.update -= CheckToolActivation;
			
			EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyItemDrawWrapper;
			EditorApplication.update += CheckToolActivation;

			void CheckToolActivation() => toolActive = EditorPrefs.GetBool(ToolActivePropertyName);
		}

		private static void OnHierarchyItemDrawWrapper(int instanceid, Rect selectionrect)
		{
			try 
			{
				OnHierarchyItemDraw(instanceid, selectionrect);
			} catch (Exception e)
			{
				Debug.Log($"<color=white> [HierarchyToolError] Lets see what stack trace says... \n{e}</color>");
			}
		}

		private static void OnHierarchyItemDraw(int instanceid, Rect selectionrect)
		{
			var gameObj = (GameObject) EditorUtility.InstanceIDToObject(instanceid);
			if (gameObj == null)
			{
				DrawFancyActivationButton(selectionrect);
				return;
			}

			if (!toolActive) return;

			Rect toggleRect = new Rect {x = selectionrect.xMax - 17, y = selectionrect.yMin, width = 15, height = 15f};

			var activated = GUI.Toggle(toggleRect, gameObj.activeSelf, "");

			if (activated != gameObj.activeSelf)
			{
				gameObj.SetActive(!gameObj.activeSelf);
				if (!Application.isPlaying)
				{
					EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
					var prefabStage = PrefabStageUtility.GetCurrentPrefabStage();
					if (prefabStage != null)
						EditorSceneManager.MarkSceneDirty(prefabStage.scene);
				}
			}

			colorThis = !colorThis;
			var xd = new Texture2D(1, 1);
			xd.SetPixel(0, 0, new Color(colorThis ? 0f : 0f, selectionrect.yMin / Screen.height, 1f - selectionrect.yMin / Screen.height, colorThis ? 0.09f : 0.04f));
			xd.Apply();
			var boxRect = new Rect {xMin = Screen.safeArea.xMin + 32f, xMax = Screen.width, yMin = selectionrect.yMin, yMax = selectionrect.yMax};
			GUI.Box(boxRect, xd, new GUIStyle {normal = {background = xd}});
		}

		private static void DrawFancyActivationButton(Rect rect)
		{
			var btnRect = new Rect {xMin = rect.xMax - 90f, xMax = rect.xMax - 5f, yMin = rect.yMin, yMax = rect.yMax};
			if (GUI.Button(btnRect, toolActive ? "disable tool" : "enable tool"))
			{
				EditorPrefs.SetBool(ToolActivePropertyName, !toolActive);
				// toolActive = !toolActive;
			}
		}
	}
}

#endif