﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dungeon.Data;
using ExtensionMethods;
using UnityEngine;

namespace Dungeon
{
	/// <summary> generates corridors, then rooms </summary>
	public class DungeonGenerator : MonoBehaviour
	{

		public DungeonMapData dungeonMapData;

		public DungeonTile corridorTileTemplate;
		public DungeonTile roomTileTemplate;
		public DungeonTile roomEntranceTileTemplate;
		public GameObject wallTemplate;
		public GameObject entranceWallTemplate;

		public float xTileSize = 1f;
		public float zTileSize = 1f;
		
		public int minCorridorLength = 5;
		public int maxCorridorLength = 10;
		public int minCorridorCount = 5;
		public int maxCorridorCount = 10;

		public Transform roomsParent;
		public Transform corridorsParent;
		public Transform wallsParent;

		[ContextMenu("GenerateNewMap()")]
		public void GenerateNewCorridor()
		{
			dungeonMapData = ScriptableObject.CreateInstance<DungeonMapData>();
			dungeonMapData.TryToAddCorridor(CorridorsGenerator.GenerateFirstCorridor(maxCorridorLength));
			InstantiateMapFromDatabase();
		}

		public void GenerateRoomWest()
		{
			RoomGenerator.GenerateWestRoom(dungeonMapData.corridors[0], dungeonMapData);
			InstantiateMapFromDatabase();
		}
		
		public void GenerateRoomNorth()
		{
			RoomGenerator.TryGenerateNorthRoom(dungeonMapData.corridors[0], dungeonMapData);
			InstantiateMapFromDatabase();
		}
		
		public void GenerateRoomEast()
		{
			RoomGenerator.TryGenerateEastRoom(dungeonMapData.corridors[0], dungeonMapData);
			InstantiateMapFromDatabase();
		}
		
		public void GenerateRoomSouth()
		{
			RoomGenerator.TryGenerateSouthRoom(dungeonMapData.corridors[0], dungeonMapData);
			InstantiateMapFromDatabase();
		}

		[ContextMenu("RemoveExistingMap()")]
		public void RemoveExistingMap()
		{
			roomsParent.DestroyChildren();
			corridorsParent.DestroyChildren();
			wallsParent.DestroyChildren();
		}

		private void InstantiateTile(Tile tile)
		{
			DungeonTile template = null;
			Transform parent = null;
			switch (tile.TileType)
			{
				case TileType.Corridor: template = corridorTileTemplate; parent = corridorsParent; break;
				case TileType.Room: template = roomTileTemplate; parent = roomsParent; break;
				case TileType.RoomEntrance: template = roomEntranceTileTemplate; parent = roomsParent; break;
			}
			InstantiateTile(template, parent, tile);
		}

		private void InstantiateTile(DungeonTile template, Transform parent, Tile tile)
		{
			var newTile = Instantiate(template, parent);
			newTile.gameObject.SetActive(true);
			newTile.transform.position = new Vector3(tile.x * xTileSize, 0f,tile.y * zTileSize);
			newTile.TileData = tile;
		}

		private void InstantiateMapFromDatabase()
		{
			RemoveExistingMap();
			foreach (var tile in dungeonMapData.AllTiles)
				InstantiateTile(tile);

			InstantiateWalls();
		}

		private void InstantiateWalls()
		{
			WallsGenerator wallsGenerator = new WallsGenerator(wallsParent, wallTemplate, entranceWallTemplate, xTileSize, zTileSize);
			wallsGenerator.GenerateWalls(dungeonMapData);
		}
	}
}