using UnityEngine;

namespace Dungeon.Data
{
	public class Tile
	{
		public int x, y;
		public TileType TileType;
		public int roomId = 0;
	}
	
	public enum TileType { None, Corridor, Room, RoomEntrance}
	public enum WallType { None, Regular, Entrance}
}