using System;
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

		public GameObject corridorTileTemplate;
		public GameObject roomTileTemplate;
		public GameObject roomEntranceTileTemplate;
		public GameObject wallTemplate;

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
			GameObject template = null;
			Transform parent = null;
			switch (tile.TileType)
			{
				case TileType.Corridor: template = corridorTileTemplate; parent = corridorsParent; break;
				case TileType.Room: template = roomTileTemplate; parent = roomsParent; break;
			}
			InstantiateTile(template, parent, tile.x, tile.y);
		}

		private void InstantiateTile(GameObject template, Transform parent, int x, int y)
		{
			var newTile = Instantiate(template, parent);
			newTile.SetActive(true);
			newTile.transform.position = new Vector3(x * xTileSize, 0f,y * zTileSize);
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
			for (int x = dungeonMapData.xMin; x <= dungeonMapData.xMax; x++)
			{
				for (int y = dungeonMapData.yMin; y <= dungeonMapData.yMax; y++)
				{
					if (dungeonMapData[x, y] == null) continue;
					if (dungeonMapData[x + 1, y] == null) InstantiateWall(dungeonMapData[x, y], WorldDirection.East);
					if (dungeonMapData[x - 1, y] == null) InstantiateWall(dungeonMapData[x, y], WorldDirection.West);
					if (dungeonMapData[x, y + 1] == null) InstantiateWall(dungeonMapData[x, y], WorldDirection.North);
					if (dungeonMapData[x, y - 1] == null) InstantiateWall(dungeonMapData[x, y], WorldDirection.South);
				}
			}
		}

		private void InstantiateWall(Tile tile, WorldDirection side)
		{
			var newWall = Instantiate(wallTemplate, wallsParent);
			var pos =  new Vector3(tile.x * xTileSize, 0f, tile.y * zTileSize);
			var rot = 0f;
			switch (side)
			{
				case WorldDirection.North: pos.z += zTileSize / 2f; rot = 90f; break;
				case WorldDirection.South: pos.z -= zTileSize / 2f; rot = 90f; break;
				case WorldDirection.East: pos.x += xTileSize / 2f; break;
				case WorldDirection.West: pos.x -= xTileSize / 2f; break;
			}
			newWall.transform.position = pos;
			newWall.transform.Rotate(Vector3.up, rot);
			newWall.gameObject.SetActive(true);
		}
	}
}