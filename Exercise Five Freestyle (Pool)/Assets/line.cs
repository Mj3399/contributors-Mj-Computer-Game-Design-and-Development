using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class line : MonoBehaviour
{

    public LineRenderer lineRenderer;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    public void rend(Vector3 sp, Vector3 ep)
    {
        lineRenderer.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = sp;
        points[1] = ep;

        lineRenderer.SetPositions(points);
    }

    public void die()
    {
        lineRenderer.positionCount = 0;
    }

    
}
