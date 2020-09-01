using System;
using UnityEngine;

namespace Dungeon
{
	public class WallsMaterialTeddyPosSetter : MonoBehaviour
	{
		public CharacterTeddy teddy;
		public Material wallsMaterial;

		public void Update()
		{
			wallsMaterial.SetVector("teddyPos", new Vector2(teddy.transform.position.x, teddy.transform.position.z));
		}
	}
}