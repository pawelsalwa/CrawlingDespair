using UnityEditor;
using UnityEngine;

namespace GameCore.Shaders
{
	public class CrawlingDespairWindowTool : EditorWindow
	{
		string myString = "Hello World";
		bool groupEnabled;
		bool myBool = true;
		float myFloat = 1.23f;

		private Object CachedFile1;
		
		// Add menu named "My Window" to the Window menu
		[MenuItem("Window/My Window")]
		static void Init()
		{
			// Get existing open window or if none, make a new one:
			CrawlingDespairWindowTool window = (CrawlingDespairWindowTool)EditorWindow.GetWindow(typeof(CrawlingDespairWindowTool));
			window.Show();
		}
		
		void OnGUI()
		{
			GUILayout.Label("Base Settings", EditorStyles.boldLabel);
			myString = EditorGUILayout.TextField("Text Field", myString);

			groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
			myBool = EditorGUILayout.Toggle("Toggle", myBool);
			myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
			EditorGUILayout.EndToggleGroup();
			
			CachedFile1 = EditorGUILayout.ObjectField(CachedFile1, typeof(UnityEngine.Object), false);

		}
	}
}