using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathLib.Math;

public class Coords
{
    public float x, y, z;

    public Coords(float x, float y) {
        this.x = x;
        this.y = y;
        this.z = -1;
    }

    public Coords(float x, float y, float z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Coords(Vector3 vec) {
        x = vec.x;
        y = vec.y;
        z = vec.z;
    }

    public static Coords Perpendicular(Coords vec) {
        float x = -vec.y;
        float y = vec.x;

        return new Coords(x, y, 0);
    }

    public Coords GetNormal()
    {
        float magnitude = MyMath.Distance(new Coords(0, 0, 0), new Coords(x, y, z));
        
        x /= magnitude;
        y /= magnitude;
        z /= magnitude;

        return new Coords(x, y, z);
    }

    #region OPERATOR OVERLOADINGS
    public static Coords operator+ (Coords a, Coords b) {
        Coords c = new Coords(a.x + b.x, a.y + b.y, a.z + b.z);
        return c;
    }

    public static Coords operator- (Coords a, Coords b) {
        Coords c = new Coords(a.x - b.x, a.y - b.y, a.z - b.z);
        return c;
    }

    public static Coords operator* (Coords a, float b) {
        Coords c = new Coords(a.x * b, a.y * b, a.z * b);
        return c;
    }

    public static Coords operator/ (Coords a, Coords b)
    {
        Coords c = new Coords(a.x / b.x, a.y / b.y, a.z / b.z);
        return c;
    }
    #endregion

    public static void DrawLine(Coords startPoint, Coords endPoint, float width, Color color) {
        GameObject line = new GameObject("Line_" + startPoint.ToString() + "_" + endPoint.ToString());
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = color;
        lineRenderer.SetPosition(0, startPoint.ToVector());
        lineRenderer.SetPosition(1, endPoint.ToVector());
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }

    public override string ToString() {
        return "(" + x + "," + y + "," + z + ")";
    }

    public Vector3 ToVector() {
        return new Vector3(x, y, z);
    }
}
