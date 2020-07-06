using UnityEngine;

namespace Dungeon.Data
{
	public class RoomGenerator
	{
		public void GenerateVerticalRoom(WorldDirection roomEntranceSide, int minY, int adjacentX)
		{
			throw new System.NotImplementedException();
		}

		private RectInt GenerateRoomAdjacentToCorridor(RectInt corridor, DungeonMapDatabase database)
		{
			var room = new RectInt(0,0, 5, 6);
			room.max = corridor.min - new Vector2Int(-1, 0);

			WorldDirection dir = WorldDirection.North;

			return room;

			// while (true)
			// {
			// 	if (room.yMin == corridor.yMax + 1)
			// 		room.MoveUp();
			// }

		}
		
		
		
		
		
	}
}