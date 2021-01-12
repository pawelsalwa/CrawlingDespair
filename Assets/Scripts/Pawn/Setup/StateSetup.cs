using System;
using System.Reflection;
using Pawn;
using SalwaExtensions;
using Tools;
using UnityEditor;
using UnityEngine;

namespace Pawn
{
	[Serializable]
	public class StateSetup
	{
		public bool HasExitTime = true;
		// [DrawIf("HasExitTime")] 
		public float ExitTime = 1f;
	}
}

// #if UNITY_EDITOR
//
// 	[CustomPropertyDrawer(typeof(DrawIfAttribute))]
// 	public class DrawIfDrawer : PropertyDrawer
// 	{
// 		private StateSetup targetObj;
//
// 		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
// 		{
// 			var attribute = fieldInfo.GetCustomAttribute(typeof(DrawIfAttribute)) as DrawIfAttribute;
// 			var fi = fieldInfo;
//
//
// 			targetObj = property.GetTargetObjectOfProperty() as StateSetup;
// 			if (targetObj.HasExitTime)
// 				EditorGUI.PropertyField(position, property, label);
// 			// var xd = obj.GetType().GetField("ExitTime");
//
// 		}
//
// 		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
// 		{
// 			return targetObj != null && targetObj.HasExitTime ? base.GetPropertyHeight(property, label) : 0f;
// 		}
// 	}
//
// #endif
