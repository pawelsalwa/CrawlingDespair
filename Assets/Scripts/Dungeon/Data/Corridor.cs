using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dungeon.Data
{
	public struct Corridor
	{
		public readonly MapPoint startingPoint;
		public readonly int length;
		public readonly WorldDirection direction;

		public Corridor(MapPoint startingPoint, WorldDirection direction, int length)
		{
			this.startingPoint = startingPoint;
			this.length = length;
			this.direction = direction;
		}

		public WorldDirection RandomPerpendicularDir
		{
			get
			{
				bool random = Random.Range(0, 2) == 0;
				if (direction == WorldDirection.North || direction == WorldDirection.South)
					return random ? WorldDirection.East : WorldDirection.West;
				else
					return random ? WorldDirection.North : WorldDirection.South;
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
		
		// public int MinX => GetAllCorridorPoints.Min(point => point.x);
		// public int MaxX => GetAllCorridorPoints.Max(point => point.x);
		// public int MinY => GetAllCorridorPoints.Min(point => point.y);
		// public int MaxY => GetAllCorridorPoints.Max(point => point.y);
		public bool Vertical => direction == WorldDirection.North || direction == WorldDirection.South;

		public void GenerateAdjacentRoom(DungeonMapDatabase currentMapData)
		{
			
		}
	}
}