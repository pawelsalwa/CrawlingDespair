using UnityEngine;

namespace Dungeon.Data
{
	public class MapPoint
	{

		public Vector2Int coords = new Vector2Int();

		public MapPoint(int x, int y)
		{
			coords.x = x;
			coords.y = y;
		}
		
		public MapPoint(Vector2Int coords)
		{
			this.coords = coords;
		}

		public MapPoint GetNextPointTowardsDir(WorldDirection direction) => GetPointTowardsDir(direction, 1);

		public MapPoint GetPointTowardsDir(WorldDirection direction, int distance)
		{
			switch (direction)
			{
				case WorldDirection.North: return new MapPoint(coords.x, coords.y + distance);
				case WorldDirection.South: return new MapPoint(coords.x, coords.y - distance);
				case WorldDirection.West: return new MapPoint(coords.x - distance, coords.y);
				case WorldDirection.East: return new MapPoint(coords.x + distance, coords.y);
			}

			return null;
		}

		public override string ToString() => $"x: {coords.x}, y: {coords.y}";
	}
}