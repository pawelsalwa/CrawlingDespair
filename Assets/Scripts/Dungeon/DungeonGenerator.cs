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
				case TileType.RoomEntrance: template = roomEntranceTileTemplate; parent = roomsParent; break;
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
					if (dungeonMapData[x, y] != null)
					{
						InstantiateTileWalls(x, y);
					} 
				}
			}
		}

		private void InstantiateTileWalls(int x, int y)
		{
			if (ShouldHaveWall(dungeonMapData[x, y], WorldDirection.East)) InstantiateWall(dungeonMapData[x, y], WorldDirection.East);
			if (ShouldHaveWall(dungeonMapData[x, y], WorldDirection.West)) InstantiateWall(dungeonMapData[x, y], WorldDirection.West);
			if (ShouldHaveWall(dungeonMapData[x, y], WorldDirection.North)) InstantiateWall(dungeonMapData[x, y], WorldDirection.North);
			if (ShouldHaveWall(dungeonMapData[x, y], WorldDirection.South)) InstantiateWall(dungeonMapData[x, y], WorldDirection.South);
		}

		private bool ShouldHaveWall(Tile tile, WorldDirection dir)
		{
			Tile tileNextTo;
			switch (dir)
			{
				case WorldDirection.East: tileNextTo = dungeonMapData[tile.x + 1, tile.y]; break;
				case WorldDirection.West: tileNextTo = dungeonMapData[tile.x - 1, tile.y]; break;
				case WorldDirection.North: tileNextTo = dungeonMapData[tile.x, tile.y + 1]; break;
				case WorldDirection.South: tileNextTo = dungeonMapData[tile.x, tile.y - 1]; break;
				default:
					throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
			}

			if (tileNextTo == null) return true;

			switch (tile.TileType) // trzeba ogarnac zeby sie nie robily duplikaty scian ale to moze jak juz zdefiniujemy jak w ogole wygladaja te korytarze
			{
				case TileType.Corridor: break;
				case TileType.Room:
					//prevents other room from placing walls in the same place (room with lower id places walls, so new ones dont place it)
					if (tile.roomId < tileNextTo.roomId) return true;
					if (tileNextTo.TileType == TileType.Corridor) return true;
					break;
				case TileType.RoomEntrance:
					if (tile.roomId < tileNextTo.roomId)
					{
						return true;
					}

					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			return false;
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