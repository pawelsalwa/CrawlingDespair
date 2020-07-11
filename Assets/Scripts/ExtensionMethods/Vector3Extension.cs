using UnityEngine;

namespace ExtensionMethods
{
	public static class Vector3Extension
	{
		public static void AddToX(this ref Vector3 vector3, float val) => vector3 = new Vector3(vector3.x + val, vector3.y, vector3.z);
		public static void AddToY(this ref Vector3 vector3, float val) => vector3 = new Vector3(vector3.x, vector3.y + val, vector3.z);
		public static void AddToZ(this ref Vector3 vector3, float val) => vector3 = new Vector3(vector3.x, vector3.y, vector3.z + val);
	}
}