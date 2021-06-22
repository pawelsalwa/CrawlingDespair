using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWallsCapsule : MonoBehaviour
{
	public Material lineMaterial;

	public float radius = 1f;

	public Color color = new Color(0f, 0.3f, 1f, 25f);

	void OnPostRender()
	{
		lineMaterial.SetPass(0);

		Draw.color = Color.white;
		// 3D
		// Draws a cube rotating around the scene origin
		Vector3 cubeForward = new Vector3(Mathf.Sin(Time.time), 0, Mathf.Cos(Time.time));
		Draw.Cube(Vector3.zero, Vector3.one, cubeForward, Vector3.up);

		Draw.Sphere(transform.position, radius, 6, 11);

		Draw.color = new Color(0, 0.2f, 1);
		Draw.color.a = 0.2f;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = color;
		Gizmos.DrawSphere(transform.position, radius);
	}
}