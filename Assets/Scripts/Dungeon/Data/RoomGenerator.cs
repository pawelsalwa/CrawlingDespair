using System;
using System.Linq;
using UnityEngine;

namespace Dungeon.Data
{
	public class RoomGenerator
	{
		// private WorldDirection NextDirClockwise(WorldDirection dir)
		// {
		// 	switch (dir)
		// 	{
		// 		case WorldDirection.North: return WorldDirection.East;
		// 		case WorldDirection.South: return WorldDirection.West;
		// 		case WorldDirection.West: return WorldDirection.North;
		// 		case WorldDirection.East: return WorldDirection.South;
		// 	}
		//
		// 	return WorldDirection.East;
		// }

		public void GenerateWestRoom(Corridor corridor, DungeonMapDatabase database)
		{
			var newRoom = new RectInt(0, 0, 4, 4);
			newRoom.MoveToSetMax(corridor.Rect.min + Vector2Int.up);
			WorldDirection dir = WorldDirection.North;

			while (true)
			{
				if (database.AllMapTiles.Any(r => r.Overlaps(newRoom))) newRoom.Move(dir);
				else 
				{
					database.RegisterRectAsRoom(newRoom);
					return;
				}
				if (newRoom.yMin >= corridor.Rect.yMax) return;
			}
		}

		public void TryGenerateNorthRoom(Corridor corridor, DungeonMapDatabase database)
		{
			var newRoom = new RectInt(0, 0, 4, 4);
			Vector2Int startPoint = new Vector2Int(corridor.Rect.xMin, corridor.Rect.yMax);
			newRoom.MoveToSetMin(startPoint + Vector2Int.left * (newRoom.width - 1));
			WorldDirection dir = WorldDirection.East;
			
			while (true)
			{
				if (database.AllMapTiles.Any(r => r.Overlaps(newRoom))) newRoom.Move(dir);
				else
				{
					database.RegisterRectAsRoom(newRoom);
					return;
				}
				if (newRoom.xMin >= corridor.Rect.xMax) return;
			}
		}
		
		public void TryGenerateEastRoom(Corridor corridor, DungeonMapDatabase database)
		{
			var newRoom = new RectInt(0, 0, 4, 4);
			newRoom.MoveToSetMin(corridor.Rect.max + Vector2Int.down);
			WorldDirection dir = WorldDirection.South;
			
			while (true)
			{
				if (database.AllMapTiles.Any(r => r.Overlaps(newRoom))) newRoom.Move(dir);
				else
				{
					database.RegisterRectAsRoom(newRoom);
					return;
				}
				if (newRoom.yMax <= corridor.Rect.yMin) return;
			}
		}
		
		public void TryGenerateSouthRoom(Corridor corridor, DungeonMapDatabase database)
		{
			var newRoom = new RectInt(0, 0, 4, 4);
			Vector2Int startPoint = new Vector2Int(corridor.Rect.xMax, corridor.Rect.yMin);
			newRoom.MoveToSetMax(startPoint + Vector2Int.right * (newRoom.width - 1));
			WorldDirection dir = WorldDirection.West;
			
			while (true)
			{
				if (database.AllMapTiles.Any(r => r.Overlaps(newRoom))) newRoom.Move(dir);
				else
				{
					database.RegisterRectAsRoom(newRoom);
					return;
				}
				if (newRoom.xMax <= corridor.Rect.xMin) return;
			}
		}
	}
}