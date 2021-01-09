using System;
using Character.Teddy;
using UnityEngine;

namespace Dungeon
{
	public class WallsMaterialTeddyPosSetter : MonoBehaviour
	{
		public CharacterTeddy teddy;
		public Material[] wallsMaterials;

		public void Update()
		{
			foreach (var wallsMaterial in wallsMaterials)
			{
				wallsMaterial.SetVector("teddyPos", new Vector2(teddy.transform.position.x, teddy.transform.position.z));
				wallsMaterial.SetVector("camPos", Camera.main.transform.position);
				
			}
		}
	}
}