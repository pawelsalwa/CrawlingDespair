using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dungeon
{
	/// <summary> Contains map data from which map can be generated </summary>
	[Serializable]
	public class DungeonMapDatabase
	{
		// [SerializeField] private List<MapTileBase> mapTiles;

		public readonly List<Corridor> corridors;

		public DungeonMapDatabase(List<Corridor> corridors)
		{
			this.corridors = corridors;
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