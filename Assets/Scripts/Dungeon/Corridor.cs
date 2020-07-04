using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
	public class Corridor
	{
		public readonly MapPoint startingPoint;
		public readonly int length;
		public readonly CorridorDirection direction;

		public Corridor(MapPoint startingPoint, CorridorDirection direction, int length)
		{
			this.startingPoint = startingPoint;
			this.length = length;
			this.direction = direction;
		}

		public CorridorDirection RandomPerpendicularDir
		{
			get
			{
				bool random = Random.Range(0, 2) == 0;
				if (direction == CorridorDirection.North || direction == CorridorDirection.South)
					return random ? CorridorDirection.East : CorridorDirection.West;
				else
					return random ? CorridorDirection.North : CorridorDirection.South;
			}
		}

		public MapPoint GetRandomCorridorPoint
		{
			get
			{
				int num = Random.Range(0, length);
				MapPoint result = startingPoint;
				for (int i = 0; i < num; i++)
					result = result.GetNextPointTowardsDir(direction);
				return result;
			}
		}

		public IEnumerable<MapPoint> GetAllCorridorPoints
		{
			get
			{
				var yieldedPoint = startingPoint;
				for (int i = 0; i < length; i++)
				{
					yield return yieldedPoint;
					yieldedPoint = yieldedPoint.GetNextPointTowardsDir(direction);
				}
			}
		}
	}
}