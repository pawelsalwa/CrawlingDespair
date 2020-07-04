using System;
using System.Collections.Generic;

namespace Dungeon.Data
{
	/// <summary> Contains map data from which map can be generated </summary>
	[Serializable]
	public class DungeonMapDatabase
	{
		// [SerializeField] private List<MapTileBase> mapTiles;

		public readonly List<Corridor> corridors = new List<Corridor>();
		public readonly List<Room> rooms = new List<Room>();

		public DungeonMapDatabase(List<Corridor> corridors)
		{
			this.corridors = corridors;
		}

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