using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dungeon.Data
{
	/// <summary> Contains map data from which map can be generated </summary>
	[Serializable]
	public class DungeonMapDatabase
	{
		// [SerializeField] private List<MapTileBase> mapTiles;

		public readonly List<Corridor> corridors = new List<Corridor>();
		public readonly List<Room> rooms = new List<Room>();

		public IEnumerable<RectInt> AllMapTiles => corridors.Select(x => x.Rect).Union(rooms.Select(x => x.Rect));
		public Vector2Int GetCorridorStartingPoint { get; set; }

		/// <summary> If provided rect doesnt overlap with existing data, its added to the database as room</summary>
		public void RegisterRectAsCorridor(RectInt rect)
		{
			if (rooms.Any(r => r.Rect.Overlaps(rect)))
			{
				Debug.LogError($"<color=red> Trying to add corridor to database that overlaps with existing room. </color>");
				return;
			}
			
			if (corridors.Any(c => c.Rect.Overlaps(rect)))
			{
				Debug.LogError($"<color=red> Trying to add corridor to database that overlaps with existing corridor. </color>");
				return;
			}

			corridors.Add(new Corridor(rect, rooms.Count));
		}
		
		/// <summary> If provided rect doesnt overlap with existing data, its added to the database as room</summary>
		public void RegisterRectAsRoom(RectInt rect)
		{
			if (rooms.Any(r => r.Rect.Overlaps(rect)))
			{
				Debug.LogError($"<color=red> Trying to add room to database that overlaps with existing room. </color>");
				return;
			}
			
			if (corridors.Any(c => c.Rect.Overlaps(rect)))
			{
				Debug.LogError($"<color=red> Trying to add room to database that overlaps with existing corridor. </color>");
				return;
			}

			rooms.Add(new Room(rect, rooms.Count));
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