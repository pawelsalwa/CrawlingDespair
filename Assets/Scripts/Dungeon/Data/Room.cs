using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.Data
{
	public class Room
	{
		public readonly RectInt Rect;
		private readonly int id;
		
		public int Id => id;

		public Room(RectInt rect, int id)
		{
			this.Rect = rect;
			this.id = id;
		}

	}
}