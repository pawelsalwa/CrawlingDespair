using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.Data
{
	public class Room
	{
		private static int LastCreatedId = 0;
		
		public readonly RectInt Rect;
		private readonly int id;
		public Vector2Int Entrance ;//= null;
		
		public int Id => id;

		public Room(RectInt rect, int id)
		{
			this.Rect = rect;
			this.id = id;
		}
		
		public Room(RectInt rect, Corridor adjacentCorridor)
		{
			this.Rect = rect;
			this.id = ++LastCreatedId;
			SetRoomEntrance(adjacentCorridor);
		}
		
		private void SetRoomEntrance(Corridor adjacentCorridor)
		{
			List<Vector2Int> allRoomConnectionPointsWithCorridor = new List<Vector2Int>();

			foreach (var roomTile in Rect.allPositionsWithin)
			{
				foreach (var point in adjacentCorridor.Rect.GetSurroundingPoints())
				{
					if (point == roomTile)
					{
						allRoomConnectionPointsWithCorridor.Add(point);
					}
				}
			}

			int randomIdx = Random.Range(0, allRoomConnectionPointsWithCorridor.Count);
			Entrance = allRoomConnectionPointsWithCorridor[randomIdx];
		}
	}
}