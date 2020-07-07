using System.Collections.Generic;
using System.Linq;
using Dungeon.Data;
using UnityEngine;

namespace Dungeon
{
	/// <summary> generates corridors, then rooms </summary>
	public class DungeonGenerator : MonoBehaviour
	{
		// private CorridorsGenerator corridorsGenerator = new CorridorsGenerator(5,10,5,10);

		private DungeonMapDatabase dungeonMapDatabase;

		public GameObject corridorTileTemplate;
		public GameObject roomTileTemplate;
		public GameObject roomEntranceTileTemplate;

		public float xTileSize = 1f;
		public float zTileSize = 1f;
		
		public int minCorridorLength = 5;
		public int maxCorridorLength = 10;
		public int minCorridorCount = 5;
		public int maxCorridorCount = 10; 

		[ContextMenu("GenerateNewMap()")]
		public void GenerateNewMap()
		{
			// dungeonMapDatabase = new DungeonMapDatabase(GenerateCorridors());

			
			dungeonMapDatabase = new DungeonMapDatabase();
			new CorridorsGenerator(minCorridorLength, maxCorridorLength, minCorridorCount, maxCorridorCount)
				.GenerateCorridorWithRoom(dungeonMapDatabase);

			// var xd = new List<Vector2Int>(dungeonMapDatabase.corridors[0].allPositionsWithin);
			// var xd1 = dungeonMapDatabase.corridors[0].allPositionsWithin.ToList();
			// var xd2 = dungeonMapDatabase.rooms.ToArray();

			
			// GenerateCorridors();
			// GenerateRooms();
			InstantiateMapFromDatabase();
			
			
		}

		public void GenerateRoom()
		{
			var room = new RoomGenerator().GenerateRoomAdjacentToCorridor(dungeonMapDatabase.corridors[0], dungeonMapDatabase);
			dungeonMapDatabase.rooms.Add(room);
			InstantiateMapFromDatabase();
		}
		
		public void GenerateRoomNorth()
		{
			new RoomGenerator().TryGenerateNorthRoom(dungeonMapDatabase.corridors[0], dungeonMapDatabase);
			InstantiateMapFromDatabase();
		}
		
		public void GenerateRoomEast()
		{
			new RoomGenerator().TryGenerateEastRoom(dungeonMapDatabase.corridors[0], dungeonMapDatabase);
			InstantiateMapFromDatabase();
		}

		[ContextMenu("RemoveExistingMap()")]
		public void RemoveExistingMap()
		{
			for (int i = transform.childCount - 1; i >= 0; i--)
			{
				if (!transform.GetChild(i).gameObject.activeSelf) continue;
				if (UnityEditor.EditorApplication.isPlaying)
					Destroy(transform.GetChild(i).gameObject);
				else
					DestroyImmediate(transform.GetChild(i).gameObject);
			}
		}

		[ContextMenu("GenerateRooms()")]
		private void GenerateRooms()
		{
		}

		// private List<Corridor> GenerateCorridors()
		// {
		// 	// return new CorridorsGenerator(minCorridorLength, maxCorridorLength, minCorridorCount, maxCorridorCount)
		// 	// 	.AddCorridorWithRoomToDatabase(dungeonMapDatabase);
		// }

		private void InstantiateMapFromDatabase()
		{
			RemoveExistingMap();
			foreach (var corridor in dungeonMapDatabase.corridors)
			{
				InstantiateCorridor(corridor);
			}
			
			foreach (var room in dungeonMapDatabase.rooms)
			{
				InstantiateRoom(room);
			}
		}

		private void InstantiateRoom(RectInt room)
		{
			// for (int x = room.xMin; x < room.xMax; x++)
			// {
			// 	for (int y = room.yMin; y < room.yMax; y++)
			// 	{
			// 		var newTile = Instantiate(roomTileTemplate, transform);
			// 		newTile.SetActive(true);
			// 		newTile.transform.position = new Vector3(x * xTileSize, 0f,y * zTileSize);
			// 	}
			// }
			
			foreach (var mapPoint in room.allPositionsWithin)
			{
				var newTile = Instantiate(roomTileTemplate, transform);
				newTile.SetActive(true);
				newTile.transform.position = new Vector3(mapPoint.x * xTileSize, 0f,mapPoint.y * zTileSize);
			}
			
			// var newTileEntrance = Instantiate(roomEntranceTileTemplate, transform);
			// newTileEntrance.SetActive(true);
			// newTileEntrance.transform.position = new Vector3(room.Entrance.x * xTileSize, 0f,room.Entrance.y * zTileSize);
		}

		private void InstantiateCorridor(RectInt corridor)
		{
			foreach (var mapPoint in corridor.allPositionsWithin)
			{
				var newTile = Instantiate(corridorTileTemplate, transform);
				newTile.SetActive(true);
				newTile.transform.position = new Vector3(mapPoint.x * xTileSize, 0f,mapPoint.y * zTileSize);
			}
		}
	}
}