using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace SalwaExtensions
{
	[CustomPropertyDrawer(typeof(DrawIfAttribute))]
	public class DrawIfDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var attribute = fieldInfo.GetCustomAttribute(typeof(DrawIfAttribute)) as DrawIfAttribute;
			var fi = fieldInfo;


			var obj = property.GetTargetObjectOfProperty();
			var xd = obj.GetType().GetField("ExitTime");

		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label);
		}
	}
}