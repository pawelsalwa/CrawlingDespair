using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.Data
{
	public class Room
	{
		private readonly MapPoint leftBottom;
		private readonly MapPoint rightUpper;
		private readonly MapPoint entrance;

		public Room(MapPoint leftBottom, MapPoint rightUpper, MapPoint entrance)
		{
			this.leftBottom = leftBottom;
			this.rightUpper = rightUpper;
			this.entrance = entrance;
		}

		public MapPoint Entrance => entrance;

		public IEnumerable<MapPoint> GetAllRoomPoints
		{
			get
			{
				for (int x = leftBottom.coords.x; x <= rightUpper.coords.x; x++)
				for (int y = leftBottom.coords.y; y <= rightUpper.coords.y; y++)
					if (!(x == entrance.coords.x && y == entrance.coords.y))
						yield return new MapPoint(x, y);
			}
		}

		public MapPoint LeftBottom { set => MoveRoom(leftBottom.coords - value.coords); }
		public MapPoint RightUpper { set => MoveRoom(rightUpper.coords - value.coords); }
		public MapPoint RightBottom { set => MoveRoom(new Vector2Int(rightUpper.coords.x, leftBottom.coords.y) - value.coords); }
		public MapPoint LeftUpper { set => MoveRoom(new Vector2Int(leftBottom.coords.x, rightUpper.coords.y) - value.coords); }

		public void MoveRoom(WorldDirection dir)
		{
			switch (dir)
			{
				case WorldDirection.North:
					leftBottom.coords.y += 1;
					rightUpper.coords.y += 1;
					entrance.coords.y += 1;
					break;
				case WorldDirection.South:
					leftBottom.coords.y -= 1;
					rightUpper.coords.y -= 1;
					entrance.coords.y -= 1;
					break;
				case WorldDirection.West:
					leftBottom.coords.x -= 1;
					rightUpper.coords.x -= 1;
					entrance.coords.x -= 1;
					break;
				case WorldDirection.East:
					leftBottom.coords.x += 1;
					rightUpper.coords.x += 1;
					entrance.coords.x += 1;
					break;
			}
		}

		public void MoveRoom(Vector2Int delta)
		{
			leftBottom.coords += delta;
			rightUpper.coords += delta;
			entrance.coords += delta;
		}
	}
}