using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{

    public LineRenderer LineRenderer;
    public int Segments = 10;

    public void Draw(Vector3 a, Vector3 b, float length)
    {
        LineRenderer.enabled = true;
        float interpolant = Vector3.Distance(a, b) / length;
        float offSet = Mathf.Lerp(length / 2, 0f, interpolant);

        Vector3 aDown = a + Vector3.down * offSet;
        Vector3 bDown = b + Vector3.down * offSet;

        LineRenderer.positionCount = Segments + 1;
        for (int i = 0; i < Segments + 1; i++)
        {
            LineRenderer.SetPosition(i, Bezier.GetPoint(a, aDown, bDown, b, (float)i / Segments));
        }
    }
    
    public void Hide()
    {
        LineRenderer.enabled = false;
    }
}
