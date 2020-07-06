using System;
using UnityEngine;

namespace Dungeon.Data
{
	public static class RectIntExtension
	{
		// public static void MoveUp(this RectInt rectInt) => 
		// 	rectInt.SetMinMax(rectInt.min + new Vector2Int(1, 0), rectInt.max + new Vector2Int(1, 0));
		
		public static void Move(this ref RectInt rectInt, WorldDirection dir)
		{
			Vector2Int added = Vector2Int.zero;
			switch (dir)
			{
				case WorldDirection.North: added = new Vector2Int(1, 0); break;
				case WorldDirection.South: added = new Vector2Int(-1, 0); break;
				case WorldDirection.West:added = new Vector2Int(0, -1); break;
				case WorldDirection.East:added = new Vector2Int(0, 1); break;
			}
			rectInt.SetMinMax(rectInt.min + added, rectInt.max + added);
		}
	}
}