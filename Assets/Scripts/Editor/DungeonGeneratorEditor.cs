using System;
using System.Collections;
using System.Collections.Generic;
using Dungeon;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DungeonGenerator))]
public class DungeonGeneratorEditor : Editor
{
	private DungeonGenerator targetObj;
	
	public override void OnInspectorGUI()
	{
		if (GUILayout.Button("Generate")) targetObj.GenerateNewMap();
		if (GUILayout.Button("Remove existing map")) targetObj.RemoveExistingMap();
		
		base.OnInspectorGUI();
	}

	private void OnEnable() => targetObj = target as DungeonGenerator;
}
