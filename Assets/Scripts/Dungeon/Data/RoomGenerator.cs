using System;
using System.Collections.Generic;
using System.Linq;
using ExtensionMethods;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dungeon.Data
{
	public static class RoomGenerator
	{

		public static void GenerateWestRoom(Corridor corridor, DungeonMapData database)
		{
			var newRoom = new RectInt(0, 0, 4, 4);
			newRoom.MoveToSetMax(corridor.Rect.min + Vector2Int.up);
			WorldDirection dir = WorldDirection.North;
		
			while (true)
			{
				if (database.Overlaps(newRoom)) newRoom.Move(dir);
				else
				{
					database.TryToAddRoom(new Room(newRoom, corridor));
					return;
				}
				if (newRoom.yMin >= corridor.Rect.yMax) return;
			}
		}
		
		public static void TryGenerateNorthRoom(Corridor corridor, DungeonMapData database)
		{
			var newRoom = new RectInt(0, 0, 4, 4);
			Vector2Int startPoint = new Vector2Int(corridor.Rect.xMin, corridor.Rect.yMax);
			newRoom.MoveToSetMin(startPoint + Vector2Int.left * (newRoom.width - 1));
			WorldDirection dir = WorldDirection.East;
			
			while (true)
			{
				if (database.Overlaps(newRoom)) newRoom.Move(dir);
				else
				{
					database.TryToAddRoom(new Room(newRoom, corridor));
					return;
				}
				if (newRoom.xMin >= corridor.Rect.xMax) return;
			}
		}
		
		public static void TryGenerateEastRoom(Corridor corridor, DungeonMapData database)
		{
			var newRoom = new RectInt(0, 0, 4, 4);
			newRoom.MoveToSetMin(corridor.Rect.max + Vector2Int.down);
			WorldDirection dir = WorldDirection.South;
			
			while (true)
			{
				if (database.Overlaps(newRoom)) newRoom.Move(dir);
				else
				{
					database.TryToAddRoom(new Room(newRoom, corridor));
					return;
				}
				if (newRoom.yMax <= corridor.Rect.yMin) return;
			}
		}
		
		public static void TryGenerateSouthRoom(Corridor corridor, DungeonMapData database)
		{
			var newRoom = new RectInt(0, 0, 4, 4);
			Vector2Int startPoint = new Vector2Int(corridor.Rect.xMax, corridor.Rect.yMin);
			newRoom.MoveToSetMax(startPoint + Vector2Int.right * (newRoom.width - 1));
			WorldDirection dir = WorldDirection.West;
			
			while (true)
			{
				if (database.Overlaps(newRoom)) newRoom.Move(dir);
				else
				{
					database.TryToAddRoom(new Room(newRoom, corridor));
					return;
				}
				if (newRoom.xMax <= corridor.Rect.xMin) return;
			}
		}

		private static void SetRoomEntrance(Room room, Corridor corridorToConnect)
		{
			List<Vector2Int> AllRoomConnectionPointsWithCorridor = new List<Vector2Int>();


			foreach (var roomTile in room.Rect.allPositionsWithin)
			{
				foreach (var point in corridorToConnect.Rect.GetSurroundingPoints())
				{
					if (point == roomTile)
					{
						AllRoomConnectionPointsWithCorridor.Add(point);
					}
				}
			}

			int randomIdx = Random.Range(0, AllRoomConnectionPointsWithCorridor.Count);
			room.Entrance = AllRoomConnectionPointsWithCorridor[randomIdx];
		}
	}
}