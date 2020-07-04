namespace Dungeon
{
	public class MapPoint
	{
		public int x, y;

		public MapPoint(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public MapPoint GetNextPointTowardsDir(CorridorDirection direction) => GetPointTowardsDir(direction, 1);

		public MapPoint GetPointTowardsDir(CorridorDirection direction, int distance)
		{
			switch (direction)
			{
				case CorridorDirection.North: return new MapPoint(x, y + distance);
				case CorridorDirection.South: return new MapPoint(x, y - distance);
				case CorridorDirection.West: return new MapPoint(x + distance, y);
				case CorridorDirection.East: return new MapPoint(x - distance, y);
			}

			return null;
		}
	}
}