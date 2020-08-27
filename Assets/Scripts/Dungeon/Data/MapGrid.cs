using System;
using System.Collections.Generic;

namespace Dungeon.Data
{
	/// <summary> actual model data for tiles grid map </summary>
	public class MapGrid
	{

		private int xMin, yMin, xMax, yMax;

		private Dictionary<int, Dictionary<int, Tile>> tiles = new Dictionary<int, Dictionary<int, Tile>>();

		public Tile this[int x, int y]
		{
			get
			{
				if (!tiles.ContainsKey(x)) return null;
				if (!tiles[x].ContainsKey(y)) return null;
				return tiles[x][y];
			}
			set
			{
				if (!tiles.ContainsKey(x)) tiles[x] = new Dictionary<int, Tile>();
				tiles[x][y] = value;
				if (x > xMax) xMax = x;
				if (x < xMin) xMin = x;
				if (y > yMax) yMax = y;
				if (y < yMin) yMin = y;
			}
		}
	}
}