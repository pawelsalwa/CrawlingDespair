using System;
using UnityEngine;

namespace Dungeon.Data
{
	public static class RectIntExtension
	{
		/// <summary> Moves provided rect, so its max equals newMax </summary>
		public static void MoveToSetMax(this ref RectInt rectInt, Vector2Int newMax)
		{
			var delta = newMax - rectInt.max;
			rectInt.SetMinMax(rectInt.min + delta, rectInt.max + delta);
		}
		
		public static void MoveToSetMin(this ref RectInt rectInt, Vector2Int newMin)
		{
			var delta = newMin - rectInt.min;  
			rectInt.SetMinMax(rectInt.min + delta, rectInt.max + delta);
		}

		public static void Move(this ref RectInt rectInt, Vector2Int motion) => rectInt.SetMinMax(rectInt.min + motion, rectInt.max + motion);

		public static void Move(this ref RectInt rectInt, WorldDirection dir, int distance = 1)
		{
			Vector2Int added = Vector2Int.zero;
			switch (dir)
			{
				case WorldDirection.North: added = new Vector2Int(0, distance); break;
				case WorldDirection.South: added = new Vector2Int(0, -distance); break;
				case WorldDirection.West: added = new Vector2Int(-distance, 0); break;
				case WorldDirection.East: added = new Vector2Int(distance, 0 ); break;
			}
			rectInt.SetMinMax(rectInt.min + added, rectInt.max + added);
		}

		public static bool Overlaps(this RectInt a, RectInt b) =>
			a.xMin < b.xMax && a.xMax > b.xMin &&
			a.yMin < b.yMax && a.yMax > b.yMin;

		public static bool Contains(this RectInt a, int x, int y) => Overlaps(a, new RectInt(x,y,0,0));
	}
}