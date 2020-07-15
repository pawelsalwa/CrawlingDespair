using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWallsSphere : MonoBehaviour
{
    public Material material;

    [Range(0f, 10f)]
    public float radius = 1f;
    public Vector3 camPosition;

    public Color color = new Color(0f, 0.3f, 1f, 25f);

    void Update()
    {
        material.SetFloat("_radius", radius);
        material.SetVector("_sphereCenter", camPosition = transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
