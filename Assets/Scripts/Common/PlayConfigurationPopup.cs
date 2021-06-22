#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace Tools
{
	public class PlayConfigurationPopup : PopupWindowContent
	{

		public override void OnGUI(Rect rect)
		{
			// var prefsValue = PlayerPrefs.GetInt(PlayerPrefsProperties.IsServerBool, 0);
			// var isServer = prefsValue == 1; 
			// 	// PlayerPrefs.GetInt(PlayerPrefsProperties.IsServerBool, 0) == 1; 
			// isServer = EditorGUILayout.Toggle("PlayAsServerOnAwake", isServer);
			//
			// if (GUI.changed)
			// {
			// 	PlayerPrefs.SetInt(PlayerPrefsProperties.IsServerBool, isServer ? 1 : 0);
			// 	// editorWindow.Close();
			// }
		}

		public override Vector2 GetWindowSize()
		{
			var size = base.GetWindowSize();
			size.y = 40f;
			return size;
		}
	}
}

#endif