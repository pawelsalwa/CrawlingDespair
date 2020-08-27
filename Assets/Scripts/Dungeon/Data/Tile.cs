using UnityEngine;

namespace Dungeon.Data
{
	public class Tile
	{
		public int x, y;
		public TileType TileType;
	}
	
	public enum TileType { None, Corridor, Room }
}