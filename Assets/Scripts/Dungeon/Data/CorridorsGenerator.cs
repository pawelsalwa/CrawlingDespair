// using System;

using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.Data
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

		public void AddCorridorWithRoomToDatabase(DungeonMapDatabase currentMapData)
		{
			Corridor corridor = GenerateCorridor(new MapPoint(0, 0), CorridorDirection.North);
			currentMapData.corridors.Add(corridor);
			GenerateAdjacentRoom(corridor, currentMapData);
		}

		public List<Corridor> GenerateCorridors()
		{
			var count = Random.Range(minCorridorCount, maxCorridorCount);
			Corridor currentCorridor = GenerateCorridor(new MapPoint(0, 0), CorridorDirection.North); // first corridor generation
			Debug.Log($"<color=white>generation {count} corridors </color>");

			// GenerateAdjacentRoom(currentCorridor);

			for (int i = 1; i < count; i++)
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

		private void GenerateAdjacentRoom(Corridor corridor, DungeonMapDatabase currentMapData)
		{
			var corridorRandomPoint = corridor.GetRandomCorridorPoint;
			if (corridor.direction == CorridorDirection.North)
			{
				var xdd = new RoomGenerator();

				var roomEntrancePoint = corridorRandomPoint.GetNextPointTowardsDir(CorridorDirection.East);

				int roomMinSize = 4;
				int roomMaxSize = 6;
				
				int roomSizeX = Random.Range(roomMinSize, roomMaxSize + 1);
				int roomSizeY = Random.Range(roomMinSize, roomMaxSize + 1);

				var random = Random.Range(0, 2) == 0;
				var yStart = roomEntrancePoint.y - roomSizeY / 2;

				var roomStartPoint = new MapPoint(roomEntrancePoint.x, yStart);

				currentMapData.rooms.Add(new Room(roomStartPoint, new MapPoint(roomStartPoint.x + roomSizeX, roomStartPoint.y + roomSizeY), roomEntrancePoint));
			}
		}
	}
}