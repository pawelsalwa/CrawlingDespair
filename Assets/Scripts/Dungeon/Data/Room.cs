using System.Collections.Generic;

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
				for (int x = leftBottom.x; x <= rightUpper.x; x++)
					for (int y = leftBottom.y; y <= rightUpper.y; y++)
						if (!(x == entrance.x && y == entrance.y))
							yield return new MapPoint(x, y);
			}
		}
	}
}