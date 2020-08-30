using System;
using System.Collections.Generic;
using Dungeon;
using UnityEngine;

namespace ExtensionMethods
{
	public static class RectIntExtension
	{
		public static IEnumerable<Vector2Int> GetSurroundingPoints(this RectInt rect)
		{
			// start from point to the low left of the rect
			Vector2Int startingPoint = new Vector2Int(rect.xMin - 1, rect.yMin - 1);
			Vector2Int point = startingPoint;
			WorldDirection dir = WorldDirection.North;
			for (int y = rect.yMin - 1; y <= rect.yMax; y++) yield return new Vector2Int(point.x, y);
			{
				yield return point;
				point.y++;
			}
			
			
			while (true)
			{
				if (point == rect.min - Vector2Int.one)
				{
					dir = WorldDirection.North;
					point.y++;
				}
				if (point == new Vector2Int(rect.xMin - 1, rect.yMax + 1))
				{
					dir = WorldDirection.East;
					point.x++;
				}
				if (point == rect.max + Vector2Int.one)
				{
					dir = WorldDirection.South;
					point.y--;
				}
				if (point == new Vector2Int(rect.xMax + 1, rect.yMin - 1))
				{
					dir = WorldDirection.West;
					point.x--;
				}
				
				yield return point;

				switch (dir)
				{
					case WorldDirection.North: point.y++; break;
					case WorldDirection.South: point.y--; break;
					case WorldDirection.East: point.x++; break;
					case WorldDirection.West: point.x--; break;
				}

				// here if point is not in surrounding bounds we change yielding dir
				// if (point.y == rect.yMax + 1 ||
				//     point.x == rect.xMax + 1 ||
				//     point.y == rect.yMin - 1 ||
				//     point.x == rect.xMin - 1
				// )
				// 	dir = NextDirClockwise(dir);

				// we break if we yielded around rect and are now back in starting pos 
				if (point == startingPoint)
					yield break;
			}
		}


		private static WorldDirection NextDirClockwise(WorldDirection dir)
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
	}
}