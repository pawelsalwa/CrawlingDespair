using System;
using System.Collections;
using System.Collections.Generic;
using Dungeon;
using UnityEngine;

namespace ExtensionMethods
{
	public static class RectIntExtension
	{
		public static bool lineSegmentsIntersect(Vector2 lineOneA, Vector2 lineOneB, Vector2 lineTwoA, Vector2 lineTwoB)
		{
			return (((lineTwoB.y - lineOneA.y) * (lineTwoA.x - lineOneA.x) > (lineTwoA.y - lineOneA.y) * (lineTwoB.x - lineOneA.x)) !=
			        ((lineTwoB.y - lineOneB.y) * (lineTwoA.x - lineOneB.x) > (lineTwoA.y - lineOneB.y) * (lineTwoB.x - lineOneB.x)) &&
			        ((lineTwoA.y - lineOneA.y) * (lineOneB.x - lineOneA.x) > (lineOneB.y - lineOneA.y) * (lineTwoA.x - lineOneA.x)) !=
			        ((lineTwoB.y - lineOneA.y) * (lineOneB.x - lineOneA.x) > (lineOneB.y - lineOneA.y) * (lineTwoB.x - lineOneA.x)));
		}


		public static Vector2Int RightBottom(this RectInt rect) =>
			new Vector2Int(rect.xMin, rect.yMax);
		
		public static Vector2Int TopLeft(this RectInt rect) =>
			new Vector2Int(rect.xMax, rect.yMin);

		public static IEnumerable<Vector2Int> GetSurroundingPoints(this RectInt rect) // TODO something is wrong with indexes here, maybe only when rectInt is 1 tile wide DONE I GUESS
		{
			var result = new List<Vector2Int>();

			for (int y = rect.yMin; y < rect.yMax; y++)
			{
				result.Add(new Vector2Int(rect.xMin - 1, y));
			}

			for (int x = rect.xMin; x < rect.xMax; x++)
			{
				result.Add(new Vector2Int(x, rect.yMax));
			}

			for (int y = rect.yMax; y > rect.yMin; y--) result.Add(new Vector2Int(rect.xMax, y));
			for (int x = rect.xMin; x < rect.xMax; x++) result.Add(new Vector2Int(x, rect.yMin - 1));

			return result;
			// // start from point to the low left of the rect
			// for (int y = rect.yMin; y <= rect.yMax; y++)
			// {
			// 	Debug.Log($"<color=white>yield {new Vector2Int(rect.xMin - 1, y)}</color>");
			// 	yield return new Vector2Int(rect.xMin - 1, y);
			// }
			//
			// for (int x = rect.xMin; x <= rect.xMax; x++)
			// {
			// 	Debug.Log($"<color=orange>yield {new Vector2Int(x, rect.yMax + 1)}</color>");
			// 	yield return new Vector2Int(x, rect.yMax + 1);
			// }
			// for (int y = rect.yMax; y >= rect.yMin; y--) yield return new Vector2Int(rect.xMax, y);
			// for (int x = rect.xMax; x > rect.xMin; x--) yield return new Vector2Int(x, rect.yMin - 1);
			// yield break;
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