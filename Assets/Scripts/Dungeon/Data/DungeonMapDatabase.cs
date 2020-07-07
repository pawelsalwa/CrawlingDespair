using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.Data
{
	/// <summary> Contains map data from which map can be generated </summary>
	[Serializable]
	public class DungeonMapDatabase
	{
		// [SerializeField] private List<MapTileBase> mapTiles;

		public readonly List<RectInt> corridors = new List<RectInt>();
		public readonly List<RectInt> rooms = new List<RectInt>();

		public DungeonMapDatabase()
		{
			
		}
			
		
		
		
		
		
		// private List
		//
		// public void TryAddTile(int x, int y)
		// {
		//
		// 	if (!DoesMapContainTile(x, y))
		// 	{
		// 		return;
		// 	}
		// 	
		// 	
		// 	
		// }
		//
		// private bool DoesMapContainTile(int x, int y) => mapTiles.Any(t => t.x == x && t.y == y);
	}
}