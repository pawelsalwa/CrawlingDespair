// using UnityEditor;
// using UnityEditorInternal;
// using UnityEngine;
//
// namespace Tools.Editor
// {
// 	[CustomEditor(typeof(ReorderableListExample))]
// 	public class ReorderableListExampleEditor : UnityEditor.Editor
// 	{
// 		private SerializedProperty damageDatasProperty;
// 		private ReorderableList reorderableList;
//
// 		public override void OnInspectorGUI()
// 		{
// 			serializedObject.Update();
// 			EditorGUILayout.PropertyField(serializedObject.FindProperty("exampleDataStruct"));
// 			reorderableList.DoLayoutList();
// 			serializedObject.ApplyModifiedProperties();
// 		}
//
// 		private void OnEnable()
// 		{
// 			damageDatasProperty = serializedObject.FindProperty("damageDatas");
// 			reorderableList = new ReorderableList(serializedObject, damageDatasProperty, true, true, true, true);
// 			reorderableList.drawElementCallback = DrawListElement;
// 			reorderableList.drawHeaderCallback = DrawHeader;
// 			reorderableList.elementHeightCallback = GetHeightOfElement;
// 		}
//
// 		private float GetHeightOfElement(int index)
// 		{
// 			SerializedProperty element = reorderableList.serializedProperty.GetArrayElementAtIndex(index);
// 			return element.isExpanded ? EditorGUI.GetPropertyHeight(element) : EditorGUIUtility.singleLineHeight;
// 		}
//
// 		private void DrawListElement(Rect rect, int index, bool isactive, bool isfocused)
// 		{
// 			SerializedProperty element = reorderableList.serializedProperty.GetArrayElementAtIndex(index); // The element in the list
// 			rect.xMin += 20;
// 			EditorGUI.PropertyField(rect, element, true);
// 		}
//
// 		private void DrawHeader(Rect rect)
// 		{
// 			EditorGUI.LabelField(rect, damageDatasProperty.name);
// 		}
// 	}
// }