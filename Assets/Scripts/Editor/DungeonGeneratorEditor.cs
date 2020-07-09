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
		if (GUILayout.Button("GenerateCorridor")) targetObj.GenerateNewCorridor();
		GUILayout.Space(20);
		if (GUILayout.Button("GenerateRoomWest")) targetObj.GenerateRoomWest();
		if (GUILayout.Button("GenerateRoomNorth")) targetObj.GenerateRoomNorth();
		if (GUILayout.Button("GenerateRoomEast")) targetObj.GenerateRoomEast();
		if (GUILayout.Button("GenerateRoomSouth")) targetObj.GenerateRoomSouth();
		GUILayout.Space(20);
		if (GUILayout.Button("Remove existing map")) targetObj.RemoveExistingMap();
		
		base.OnInspectorGUI();
	}

	private void OnEnable() => targetObj = target as DungeonGenerator;
}
