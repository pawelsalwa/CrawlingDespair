// using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
	public class CorridorsGenerator
	{
		private readonly int minCorridorLength;
		private readonly int maxCorridorLength;
		private readonly int minCorridorCount;
		private readonly int maxCorridorCount; 

		private List<Corridor> corridors = new List<Corridor>();

		public CorridorsGenerator( int minCorridorLength,
			int maxCorridorLength,
			int minCorridorCount,
			int maxCorridorCount)
		{
			this.minCorridorLength = minCorridorLength;
			this.maxCorridorLength = maxCorridorLength;
			this.minCorridorCount = minCorridorCount;
			this.maxCorridorCount = maxCorridorCount;
		}

		public List<Corridor> GenerateCorridors()
		{
			var count = Random.Range(minCorridorCount, maxCorridorCount);
			Corridor currentCorridor = GenerateCorridor(new MapPoint(0, 0), CorridorDirection.North); // first corridor generation

			for (int i = 0; i < count; i++)
			{
				var dir = currentCorridor.RandomPerpendicularDir;
				var newStartingPoint = currentCorridor.GetRandomCorridorPoint.GetNextPointTowardsDir(dir);
				currentCorridor = GenerateCorridor(newStartingPoint, dir);
			}

			return corridors;
		}

		private Corridor GenerateCorridor(MapPoint startingPoint, CorridorDirection direction)
		{
			var result = new Corridor(startingPoint, direction, Random.Range(minCorridorLength, maxCorridorLength));
			corridors.Add(result);
			return result;
		}
	}
}