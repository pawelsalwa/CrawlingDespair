using Common.Utility;
using UnityEditor;
using UnityEngine;

namespace Editor
{
	[CustomPropertyDrawer(typeof(Optional<>))]
	public class OptionalDrawer : PropertyDrawer
	{

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{

			EditorGUI.BeginProperty(position, label, property);
			var enabledRect = position;
			enabledRect.yMax = enabledRect.yMin + EditorGUIUtility.singleLineHeight;
			var enabledProp = property.FindPropertyRelative("enabled");
			
			{
				var toggleRect = position;
				toggleRect.xMin = Screen.width * 0.375f;
				enabledProp.boolValue = EditorGUI.Toggle(toggleRect, enabledProp.boolValue);
			}
			{
				var cache = GUI.enabled;
				GUI.enabled = enabledProp.boolValue;
				var valueRect = position;
				valueRect.yMin = valueRect.yMin + EditorGUIUtility.singleLineHeight;
				var valueProp = property.FindPropertyRelative("value");
				EditorGUI.PropertyField(position, valueProp, label);
				GUI.enabled = cache;
			}

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => EditorGUIUtility.singleLineHeight * 1f;
	}
}