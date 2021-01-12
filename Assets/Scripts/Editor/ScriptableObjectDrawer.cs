using GameCore;
using UnityEngine;
using UnityEditor;
 
[CustomPropertyDrawer(typeof(InspectableAttribute), true)]
public class ScriptableObjectDrawer : PropertyDrawer
{
	
	private Editor editor = null; // Cached scriptable object editor
	private bool expanded;
 
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.PropertyField(position, property, label, true);
     
		
		if (property.objectReferenceValue != null) expanded = EditorGUI.Foldout(position, expanded, GUIContent.none);
		if (!expanded) return;
		
		EditorGUI.indentLevel++;
		if (!editor) Editor.CreateCachedEditor(property.objectReferenceValue, null, ref editor);
		
		EditorGUI.BeginChangeCheck();
		if (editor) // catch for empty property
			editor.DrawDefaultInspector();
		if (EditorGUI.EndChangeCheck())
			property.serializedObject.ApplyModifiedProperties();
		EditorGUI.indentLevel--;
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return expanded ? EditorGUI.GetPropertyHeight(property, label) : EditorGUIUtility.singleLineHeight;
	}
}



// THIS FIXES UNITY EDITOR BUG XD this is broken....
[CanEditMultipleObjects]
[CustomEditor(typeof(UnityEngine.Object), true)]
public class UnityObjectEditor : Editor
{
}