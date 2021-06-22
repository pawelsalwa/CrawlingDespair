using System;
using Dungeon.Data;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Dungeon
{
	
	public class WallsGenerator
	{
		private readonly Transform wallsParent;
		private readonly GameObject wallTemplate;
		private readonly GameObject entranceWallTemplate;
		private readonly Vector2 tileSize;

		private DungeonMapData dungeonMapData;

		public WallsGenerator(Transform wallsParent, GameObject wallTemplate, GameObject entranceWallTemplate, Vector2 tileSize)
		{
			this.wallsParent = wallsParent;
			this.wallTemplate = wallTemplate;
			this.entranceWallTemplate = entranceWallTemplate;
			this.tileSize = tileSize;
		}
		
		public void GenerateWalls(DungeonMapData data)
		{
			dungeonMapData = data;
		
			for (int x = dungeonMapData.xMin; x <= dungeonMapData.xMax; x++)
			{
				for (int y = dungeonMapData.yMin; y <= dungeonMapData.yMax; y++)
				{
					if (dungeonMapData[x, y] != null)
					{
						InstantiateTileWalls(x, y);
					} 
				}
			}
		}

		private void InstantiateTileWalls(int x, int y)
		{
			var wallType = GetWallType(dungeonMapData[x, y], WorldDirection.East);
			InstantiateWall(GetWallTemplate(wallType), dungeonMapData[x, y], WorldDirection.East);
			wallType = GetWallType(dungeonMapData[x, y], WorldDirection.West);
			InstantiateWall(GetWallTemplate(wallType), dungeonMapData[x, y], WorldDirection.West);
			wallType = GetWallType(dungeonMapData[x, y], WorldDirection.North);
			InstantiateWall(GetWallTemplate(wallType), dungeonMapData[x, y], WorldDirection.North);
			wallType = GetWallType(dungeonMapData[x, y], WorldDirection.South);
			InstantiateWall(GetWallTemplate(wallType), dungeonMapData[x, y], WorldDirection.South);
		}
		
		public WallType GetWallType(Tile tile, WorldDirection dir)
		{
			Tile tileNextTo;
			switch (dir)
			{
				case WorldDirection.East: tileNextTo = dungeonMapData[tile.x + 1, tile.y]; break;
				case WorldDirection.West: tileNextTo = dungeonMapData[tile.x - 1, tile.y]; break;
				case WorldDirection.North: tileNextTo = dungeonMapData[tile.x, tile.y + 1]; break;
				case WorldDirection.South: tileNextTo = dungeonMapData[tile.x, tile.y - 1]; break;
				default:
					throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
			}

			if (tileNextTo == null) return WallType.Regular;
			switch (tile.TileType) // trzeba ogarnac zeby sie nie robily duplikaty scian ale to moze jak juz zdefiniujemy jak w ogole wygladaja te korytarze
			{
				case TileType.Corridor:
					if (tileNextTo.TileType == TileType.Corridor)
						return WallType.None;
					break;
				case TileType.Room:
					//prevents other room from placing walls in the same place (room with lower id places walls, so new ones dont place it)
					if (tile.roomId < tileNextTo.roomId) return WallType.Regular;
					if (tileNextTo.TileType == TileType.Corridor) return WallType.Regular;
					if (tileNextTo.TileType == TileType.RoomEntrance || tileNextTo.TileType == TileType.Room) return WallType.None;
					break;
				case TileType.RoomEntrance:
					if (tile.roomId < tileNextTo.roomId)
						return WallType.Regular;
					if (tileNextTo.TileType == TileType.Corridor)
						return WallType.Entrance;
					break;
			}
			return WallType.None;
		}

		private GameObject GetWallTemplate(WallType type)
		{
			switch (type)
			{
				case WallType.None: return null;
				case WallType.Regular: return wallTemplate;
				case WallType.Entrance: return entranceWallTemplate;
			}
			return null;
		}

		private void InstantiateWall(GameObject template, Tile tile, WorldDirection side)
		{
			if (template == null) return;
			var newWall = Object.Instantiate(template, wallsParent);
			var pos =  new Vector3(tile.x * tileSize.x, 0f, tile.y * tileSize.y);
			var rot = 0f;
			switch (side)
			{
				case WorldDirection.North: pos.z += tileSize.y / 2f; break;
				case WorldDirection.South: pos.z -= tileSize.y / 2f; break;
				case WorldDirection.East: pos.x += tileSize.x / 2f; rot = 90f; break;
				case WorldDirection.West: pos.x -= tileSize.x / 2f; rot = 90f; break;
			}
			newWall.transform.position = pos;
			newWall.transform.Rotate(Vector3.up, rot);
			newWall.gameObject.SetActive(true);
			SetWallSection(newWall, tile, side);
		}

		public void SetWallSection(GameObject wall, Tile tile, WorldDirection dir)
		{
			if (tile.TileType == TileType.Corridor) return;
			var room = dungeonMapData.GetRoom(tile.roomId);
			Vector2 pos1 = Vector2.zero, pos2 = Vector2.zero;
			Vector2 leftBottom, leftTop, rightTop, rightBottom;

			leftBottom = room.Rect.min * tileSize - Vector2.one * tileSize / 2f;
			leftTop = room.Rect.TopLeft() * tileSize - Vector2.one * tileSize / 2f;
			rightTop = room.Rect.max * tileSize - Vector2.one * tileSize / 2f;
			rightBottom = room.Rect.RightBottom() * tileSize - Vector2.one * tileSize / 2f;
			
			
			// leftBottom = new Vector2(room.Rect.min.x * xTileSize - xTileSize / 2f, room.Rect.min.y * zTileSize - zTileSize / 2f);
			// leftTop = new Vector2(room.Rect.min.x * xTileSize - xTileSize / 2f, room.Rect.max.y * zTileSize + zTileSize / 2f);
			// rightTop = new Vector2(room.Rect.max.x * xTileSize + xTileSize / 2f,  room.Rect.max.y * zTileSize + zTileSize / 2f);
			// rightBottom = new Vector2(room.Rect.min.x * xTileSize + xTileSize / 2f, room.Rect.min.y * zTileSize - zTileSize / 2f);
			
			switch (dir)
			{
				case WorldDirection.North: pos1 = leftTop + Vector2.left; pos2 = rightTop + Vector2.right; break;
					// pos1.x = room.Rect.min.x * xTileSize - xTileSize / 2f; // left top
					// pos1.y = room.Rect.max.y * zTileSize + zTileSize / 2f;
					//
					// pos2.x = room.Rect.max.x * xTileSize + xTileSize / 2f; // right top
					// pos2.y = room.Rect.max.y * zTileSize + zTileSize / 2f;
				case WorldDirection.South: pos1 = leftBottom + Vector2.left; pos2 = rightBottom + Vector2.right; break;
					// pos1.x = room.Rect.min.x * xTileSize - xTileSize / 2f; // left bottom
					// pos1.y = room.Rect.min.y * zTileSize - zTileSize / 2f;
					//
					// pos2.x = room.Rect.min.x * xTileSize + xTileSize / 2f; // right bottom
					// pos2.y = room.Rect.min.y * zTileSize - zTileSize / 2f;
				case WorldDirection.West: pos1 = leftBottom + Vector2.down; pos2 = leftTop + Vector2.up; break;
					// pos1.x = room.Rect.min.x * xTileSize - xTileSize / 2f; // left bottom
					// pos1.y = room.Rect.min.y * zTileSize - zTileSize / 2f;
					//
					// pos2.x = room.Rect.min.x * xTileSize - xTileSize / 2f; // left top
					// pos2.y = room.Rect.max.y * zTileSize + zTileSize / 2f;
				case WorldDirection.East: pos1 = rightBottom + Vector2.down; pos2 = rightTop + Vector2.up; break;
					// pos1.x = room.Rect.max.x * xTileSize + xTileSize / 2f; // right bottom
					// pos1.y = room.Rect.min.y * zTileSize - zTileSize / 2f;
					//
					// pos2.x = room.Rect.max.x * xTileSize + xTileSize / 2f; // right top
					// pos2.y = room.Rect.max.y * zTileSize + zTileSize / 2f;
			}

			var block = new MaterialPropertyBlock();
			block.SetVector("pos1", pos1);
			block.SetVector("pos2", pos2);
			wall.GetComponent<Renderer>().SetPropertyBlock(block);
			wall.transform.GetChild(0).GetComponent<Renderer>().SetPropertyBlock(block);
		}
	}
}