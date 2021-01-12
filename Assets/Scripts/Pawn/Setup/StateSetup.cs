using System;
using System.Reflection;
using SalwaExtensions;
using Tools;
using UnityEditor;
using UnityEngine;

namespace Pawn
{
	[Serializable]
	public class StateSetup
	{
		public bool HasExitTime = false;
		[DrawIf("HasExitTime")]
		public float ExitTime = 1f;
	}


	[AttributeUsage(AttributeTargets.Field)]
	public class DrawIfAttribute : PropertyAttribute
	{
		public string boolFieldName;

		public DrawIfAttribute(string boolFieldName)
		{
			this.boolFieldName = boolFieldName;
		}
	
	}

// #if UNITY_EDITOR
//
// [CustomPropertyDrawer(typeof(DrawIfAttribute))]
// public class DrawIfDrawer : PropertyDrawer
// {
// 	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
// 	{
// 		var attribute = fieldInfo.GetCustomAttribute(typeof(DrawIfAttribute)) as DrawIfAttribute;
// 		// fieldInfo.get
// 		
// 		
// 		var obj = property.GetTargetObjectOfProperty();
// 		var xd = obj.GetType().GetField();
// 		
// 	}
//
// 	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
// 	{
// 		return base.GetPropertyHeight(property, label);
// 	}
// }
//
// #endif
}