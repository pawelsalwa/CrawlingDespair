using Character.SetupData;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AnimatorSetupBase), true)]
public class AnimatorSetupBasePropertyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property.isExpanded)
            return EditorGUI.GetPropertyHeight(property) + 20f;
        return EditorGUI.GetPropertyHeight(property);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PropertyField(position, property, label, true);
        if (property.isExpanded)
        {
            if (GUI.Button(new Rect(position.xMin + 30f, position.yMax - 20f, position.width - 30f, 20f), "Setup hashes"))
            {
                ((AnimatorSetupBase) fieldInfo.GetValue(property.serializedObject.targetObject)).Init();
            }
        }
    }
}