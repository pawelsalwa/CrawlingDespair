using System;
using UnityEngine;

public class GizmoSphere : MonoBehaviour
{
    public bool drawOnlyWhenSelected = true;
    public Color color = Color.blue;
    public float radius = 1f;

    private void OnDrawGizmos()
    {
        if (!drawOnlyWhenSelected) Draw();
    }

    private void OnDrawGizmosSelected()
    {
        if (drawOnlyWhenSelected) Draw();
    }

    private void Draw()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
