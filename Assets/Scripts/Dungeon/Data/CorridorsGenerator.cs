
using UnityEngine;

namespace Dungeon.Data
{
	public static class CorridorsGenerator
	{
		// private readonly int minCorridorLength;
		// private readonly int maxCorridorLength;
		// private readonly int minCorridorCount;
		// private readonly int maxCorridorCount;

		// private List<Corridor> corridors = new List<Corridor>();

		// public CorridorsGenerator(int minCorridorLength,
		// 	int maxCorridorLength,
		// 	int minCorridorCount,
		// 	int maxCorridorCount)
		// {
		// 	this.minCorridorLength = minCorridorLength;
		// 	this.maxCorridorLength = maxCorridorLength;
		// 	this.minCorridorCount = minCorridorCount;
		// 	this.maxCorridorCount = maxCorridorCount;
		// }

		// private RectInt corridor;

		// public void GenerateNewCorridor(DungeonMapData database)
		// {
		// 	// if (database.corridors.Count == 0)
		// 	// {
		// 		GenerateFirstCorridor(database);
		// 		return;
		// 	// }
		// 	//
		// 	// var lastCorridor = database.corridors[database.corridors.Count - 1];
		// 	// var length = Random.Range(minCorridorLength, maxCorridorLength);
		// 	//
		// 	// if (lastCorridor.Horizontal)
		// 	// {
		// 	// 	RectInt tmpVertical = new RectInt(0, 0, 0, length);
		// 	// }
		// 	// else
		// 	// {
		// 	// 	RectInt tmpHorizontal = new RectInt(0, 0, length, 0);
		// 	// }
		// }

		public static Corridor GenerateFirstCorridor(int length) => new Corridor(new RectInt(0, 0, 1, length), 0);
		
			// database.TryToAddCorridor(new Corridor(new RectInt(0, 0, 1, maxCorridorLength), 0 ));

		// public void GenerateCorridorWithTwoNext(DungeonMapData database)
		// {
		// 	// corridor = new RectInt(0, 0, 1, 10);
		// 	// database.corridors.Add(corridor);
		// }
		
		


		// public void AddCorridorWithRoomToDatabase(DungeonMapDatabase mapDatabase)
		// {
		// 	Corridor corridor = GenerateCorridor(new MapPoint(0, 0), WorldDirection.North);
		// 	mapDatabase.corridors.Add(corridor);
		// 	GenerateAdjacentRoom(corridor, mapDatabase);
		// }
		//
		// public List<Corridor> GenerateCorridors()
		// {
		// 	var count = Random.Range(minCorridorCount, maxCorridorCount);
		// 	Corridor currentCorridor = GenerateCorridor(new MapPoint(0, 0), WorldDirection.North); // first corridor generation
		// 	Debug.Log($"<color=white>generation {count} corridors </color>");
		//
		// 	// GenerateAdjacentRoom(currentCorridor);
		//
		// 	for (int i = 1; i < count; i++)
		// 	{
		// 		var dir = currentCorridor.RandomPerpendicularDir;
		// 		var newStartingPoint = currentCorridor.GetRandomCorridorPoint.GetNextPointTowardsDir(dir);
		// 		currentCorridor = GenerateCorridor(newStartingPoint, dir);
		// 	}
		//
		// 	return corridors;
		// }
		//
		// private Corridor GenerateCorridor(MapPoint startingPoint, WorldDirection direction)
		// {
		// 	var result = new Corridor(startingPoint, direction, Random.Range(minCorridorLength, maxCorridorLength));
		// 	corridors.Add(result);
		// 	return result;
		// }
		//
		// private void GenerateAdjacentRoom(Corridor corridor, DungeonMapDatabase currentMapData)
		// {
		// 	var roomGenerator = new RoomGenerator();
		//
		// 	int minX, maxX,minY = 0, maxY = 0;
		// 	int minSideSize = 6, maxSideSize = Mathf.Max(12, corridor.length);
		//
		// 	WorldDirection roomEntranceSide = WorldDirection.North;
		// 	switch (corridor.direction)
		// 	{
		// 		case WorldDirection.South:
		// 		case WorldDirection.North: roomEntranceSide = Utilities.RandomBool ? WorldDirection.East : WorldDirection.West; break;
		// 		case WorldDirection.West:
		// 		case WorldDirection.East: roomEntranceSide = Utilities.RandomBool ? WorldDirection.South : WorldDirection.North; break;
		// 	}
		//
		// 	// int adjacentX = corridor.startingPoint.x + (roomEntranceSide == WorldDirection.East ? -1 : 1);
		// 	// roomGenerator.GenerateVerticalRoom(roomEntranceSide, corridor.MinY, adjacentX, minSideSize, maxSideSize);
		//
		//
		// 	// corridor.GenerateAdjacentRoom(currentMapData);
		// 	
		// 	var corridorRandomPoint = corridor.GetRandomCorridorPoint;
		// 	if (corridor.direction == WorldDirection.North)
		// 	{
		// 		var xdd = new RoomGenerator();
		//
		// 		var roomEntrancePoint = corridorRandomPoint.GetNextPointTowardsDir(WorldDirection.East);
		//
		// 		int roomMinSize = 4;
		// 		int roomMaxSize = 6;
		// 		
		// 		int roomSizeX = Random.Range(roomMinSize, roomMaxSize + 1);
		// 		int roomSizeY = Random.Range(roomMinSize, roomMaxSize + 1);
		//
		// 		var random = Random.Range(0, 2) == 0;
		// 		// var yStart = roomEntrancePoint.y - roomSizeY / 2;
		// 		//
		// 		// var roomStartPoint = new MapPoint(roomEntrancePoint.x, yStart);
		// 		//
		// 		// currentMapData.rooms.Add(new Room(roomStartPoint, new MapPoint(roomStartPoint.x + roomSizeX, roomStartPoint.y + roomSizeY), roomEntrancePoint));
		// 	}
		// }
	}
}