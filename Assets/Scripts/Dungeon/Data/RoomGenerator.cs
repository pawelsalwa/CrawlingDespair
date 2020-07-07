using System;
using System.Linq;
using UnityEngine;

namespace Dungeon.Data
{
	public class RoomGenerator
	{
		private WorldDirection NextDirClockwise(WorldDirection dir)
		{
			switch (dir)
			{
				case WorldDirection.North: return WorldDirection.East;
				case WorldDirection.South: return WorldDirection.West;
				case WorldDirection.West: return WorldDirection.North;
				case WorldDirection.East: return WorldDirection.South;
			}

			return WorldDirection.East;
		}

		public RectInt GenerateRoomAdjacentToCorridor(RectInt corridor, DungeonMapDatabase database)
		{
			var newRoom = new RectInt(0, 0, 4, 4);
			newRoom.MoveToSetMax(corridor.min + Vector2Int.up);
			WorldDirection dir = WorldDirection.North;

			while (true)
			{
				if (newRoom.yMin >= corridor.yMax && dir != WorldDirection.East)
				{
					dir = WorldDirection.East;
					newRoom.MoveToSetMin(corridor.max + Vector2Int.left * newRoom.width);
				}
				if (database.rooms.Any(r => r.Overlaps(newRoom))) newRoom.Move(dir);
				else return newRoom;
			}
		}

		public void TryGenerateNorthRoom(RectInt corridor, DungeonMapDatabase database)
		{
			var newRoom = new RectInt(0, 0, 4, 4);
			Vector2Int startPoint = new Vector2Int(corridor.xMin, corridor.yMax);
			newRoom.MoveToSetMin(startPoint + Vector2Int.left * (newRoom.width - 1));
			WorldDirection dir = WorldDirection.East;
			
			while (true)
			{
				if (database.rooms.Any(r => r.Overlaps(newRoom))) newRoom.Move(dir);
				else
				{
					database.rooms.Add(newRoom);
					return;
				}
				if (newRoom.xMin >= corridor.xMax) return;
			}
		}
		
		public void TryGenerateEastRoom(RectInt corridor, DungeonMapDatabase database)
		{
			var newRoom = new RectInt(0, 0, 4, 4);
			newRoom.MoveToSetMin(corridor.max + Vector2Int.down);
			WorldDirection dir = WorldDirection.South;
			
			while (true)
			{
				if (database.rooms.Any(r => r.Overlaps(newRoom))) newRoom.Move(dir);
				else
				{
					database.rooms.Add(newRoom);
					return;
				}
				if (newRoom.yMax <= corridor.yMin) return;
			}
		}
	}
}