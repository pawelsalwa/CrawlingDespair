using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Dungeon.Data
{
	/// <summary> Contains map data from which map can be generated </summary>
	[CreateAssetMenu(fileName = "DungeonMapData", menuName = "DungeonMapData", order = 0)]
	public class DungeonMapData : ScriptableObject
	{
		public readonly List<Corridor> corridors = new List<Corridor>();
		public readonly List<Room> rooms = new List<Room>();

		public IEnumerable<Tile> AllTiles => from x in map.Keys from y in map[x].Keys select map[x][y];

		// foreach (var x in map.Keys)
		// foreach (var y in map[x].Keys)
		// yield return map[x][y];

		public int xMin, yMin, xMax, yMax;

		/// <summary> first int means x coordinate, second means y </summary>
		private Dictionary<int, Dictionary<int, Tile>> map = new Dictionary<int, Dictionary<int, Tile>>();

		public Tile this[int x, int y]
		{
			get
			{
				if (!map.ContainsKey(x)) return null;
				if (!map[x].ContainsKey(y)) return null;
				return map[x][y];
			}
			set
			{
				if (!map.ContainsKey(x)) map[x] = new Dictionary<int, Tile>();
				map[x][y] = value;
				if (x > xMax) xMax = x;
				if (x < xMin) xMin = x;
				if (y > yMax) yMax = y;
				if (y < yMin) yMin = y;
			}
		}

		public void TryToAddCorridor(Corridor corridor)
		{
			if (Overlaps(corridor.Rect, out var overlappingPoint))
			{
				Debug.Log($"<color=red> Trying to add corridor to map database that overlaps on point: {overlappingPoint}]</color>");
				return;
			}

			foreach (var coord in corridor.Rect.allPositionsWithin)
			{
				this[coord.x, coord.y] = new Tile {x = coord.x, y = coord.y, TileType = TileType.Corridor};
			}

			corridors.Add(corridor);
		}
		
		public void TryToAddRoom(Room room)
		{
			if (Overlaps(room.Rect, out var overlappingPoint))
			{
				Debug.Log($"<color=red> Trying to add room to map database that overlaps on point: {overlappingPoint}]</color>");
				return;
			}

			foreach (var coord in room.Rect.allPositionsWithin)
			{
				this[coord.x, coord.y] = new Tile {x = coord.x, y = coord.y, TileType = TileType.Room};
			}

			rooms.Add(room);
		}

		public bool Overlaps(RectInt rect) => Overlaps(rect, out _);
		
		/// <summary> Does provided rect overlap with existing map? </summary>
		public bool Overlaps(RectInt rect, out Vector2Int overlappingPoint)
		{
			overlappingPoint = Vector2Int.zero;
			foreach (var coord in rect.allPositionsWithin)
			{
				if (this[coord.x, coord.y] != null)
				{
					// Debug.Log($"<color=red> Trying to add corridor to map database that overlaps on point: [{coord.x}][{coord.y}]</color>");
					overlappingPoint = new Vector2Int(coord.x, coord.y);
					return true;
				}
			}
			return false;
		}

		// /// <summary> If provided rect doesnt overlap with existing data, its added to the database as room</summary>
		// public void RegisterRectAsCorridor(RectInt rect)
		// {
		// 	if (rooms.Any(r => r.Rect.Overlaps(rect)))
		// 	{
		// 		Debug.LogError($"<color=red> Trying to add corridor to database that overlaps with existing room. </color>");
		// 		return;
		// 	}
		//
		// 	if (corridors.Any(c => c.Rect.Overlaps(rect)))
		// 	{
		// 		Debug.LogError($"<color=red> Trying to add corridor to database that overlaps with existing corridor. </color>");
		// 		return;
		// 	}
		//
		// 	corridors.Add(new Corridor(rect, rooms.Count));
		// 	RecalculateDatabase();
		// }

		// /// <summary> If provided rect doesnt overlap with existing data, its added to the database as room</summary>
		// public void RegisterRectAsRoom(RectInt rect)
		// {
		// 	if (rooms.Any(r => r.Rect.Overlaps(rect)))
		// 	{
		// 		Debug.LogError($"<color=red> Trying to add room to database that overlaps with existing room. </color>");
		// 		return;
		// 	}
		//
		// 	if (corridors.Any(c => c.Rect.Overlaps(rect)))
		// 	{
		// 		Debug.LogError($"<color=red> Trying to add room to database that overlaps with existing corridor. </color>");
		// 		return;
		// 	}
		//
		// 	rooms.Add(new Room(rect, rooms.Count));
		// 	RecalculateDatabase();
		// }

		// /// <summary> saves variables for further usage for performance reasons </summary>
		// private void RecalculateDatabase()
		// {
		// 	allMapTiles = corridors.Select(x => x.Rect).Union(rooms.Select(x => x.Rect)).ToList();
		// 	xMin = allMapTiles.Min(tile => tile.xMin);
		// 	yMin = allMapTiles.Min(tile => tile.yMin);
		// 	xMax = allMapTiles.Max(tile => tile.xMax);
		// 	yMax = allMapTiles.Max(tile => tile.yMax);
		//
		// 	map.Clear();
		// 	for (int x = xMin; x < xMax; x++)
		// 	for (int y = yMin; y < yMax; y++)
		// 		map[x][y] = new Tile {TileType = TileType.None};
		//
		// 	foreach (var corr in corridors)
		// 	foreach (var item in corr.Rect.allPositionsWithin)
		// 		map[item.x][item.y].TileType = TileType.Corridor;
		//
		// 	foreach (var corr in rooms)
		// 	foreach (var item in corr.Rect.allPositionsWithin)
		// 		map[item.x][item.y].TileType = TileType.Corridor;
		// }
	}
}