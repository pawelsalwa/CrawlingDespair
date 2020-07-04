using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
	/// <summary> generates corridors, then rooms </summary>
	public class DungeonGenerator : MonoBehaviour
	{
		// private CorridorsGenerator corridorsGenerator = new CorridorsGenerator(5,10,5,10);

		private DungeonMapDatabase dungeonMapDatabase;

		public GameObject dungeonTileTemplate;

		public float xTileSize = 1f;
		public float zTileSize = 1f;
		
		public int minCorridorLength = 5;
		public int maxCorridorLength = 10;
		public int minCorridorCount = 5;
		public int maxCorridorCount = 10; 

		[ContextMenu("GenerateNewMap()")]
		public void GenerateNewMap()
		{
			dungeonMapDatabase = new DungeonMapDatabase(GenerateCorridors());

			RemoveExistingMap();
			// GenerateCorridors();
			// GenerateRooms();
			InstantiateMapFromDatabase();
		}

		private void RemoveExistingMap()
		{
			for (int i = transform.childCount - 1; i >= 0; i--)
			{
				if (!transform.GetChild(i).gameObject.activeSelf) continue;
				if (UnityEditor.EditorApplication.isPlaying)
					Destroy(transform.GetChild(i).gameObject);
				else
					DestroyImmediate(transform.GetChild(i).gameObject);
			}
		}

		[ContextMenu("GenerateRooms()")]
		private void GenerateRooms()
		{
		}

		private List<Corridor> GenerateCorridors()
		{
			return new CorridorsGenerator(minCorridorLength, maxCorridorLength, minCorridorCount, maxCorridorCount)
				.GenerateCorridors();
		}

		private void InstantiateMapFromDatabase()
		{
			foreach (var corridor in dungeonMapDatabase.corridors)
			{
				InstantiateCorridor(corridor);
			}
		}

		private void InstantiateCorridor(Corridor corridor)
		{
			foreach (var mapPoint in corridor.GetAllCorridorPoints)
			{
				var newTile = Instantiate(dungeonTileTemplate, transform);
				newTile.SetActive(true);
				newTile.transform.position = new Vector3(mapPoint.x * xTileSize, 0f,mapPoint.y * zTileSize);
			}
		}
	}
}