using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathLib.Math;

public class Line
{
    public enum LINETYPE { LINE, SEGEMENT, RAY }

    public Coords a;
    public Coords b;
    public Coords v;

    private LINETYPE lineType;

    public Line(Coords _a, Coords _b, LINETYPE _lineType) {
        a = _a;
        b = _b;
        lineType = _lineType;
        
        v = b - a;
    }

    public Line(Coords _a, Coords vec) {
        a = _a;
        b = _a + vec;
        v = vec;
        lineType = LINETYPE.SEGEMENT;
    }

    public Coords Reflect(Coords normals)
    {
        Coords normal_vec = normals.GetNormal();
        Coords impactVec_normal = v.GetNormal();
     
        float d = MyMath.DotProduct(impactVec_normal, normal_vec);

        if (d == 0)
            return v;
        
        float vn2 = d * 2;

        Coords reflect = impactVec_normal - normal_vec * vn2;
        return reflect;
    }

    public float IntersectionAt(Plane p)
    {
        Coords normals = MyMath.CrossProduct(p.v, p.u);
        if (MyMath.DotProduct(normals, v) == 0)
            return float.NaN;

        float t = -MyMath.DotProduct(normals, this.a - p.A) / MyMath.DotProduct(normals, this.v);

        return t;
    }

    public float IntersectionAt(Line l) {       
        if(MyMath.DotProduct(Coords.Perpendicular(l.v), v) == 0) {
            return float.NaN;
        }

        Coords c = l.a - this.a;
        Coords uPerp = Coords.Perpendicular(l.v);
        float t = MyMath.DotProduct(uPerp, c) / MyMath.DotProduct(uPerp, this.v); 

        if(t < 0 || t > 1 && lineType == LINETYPE.SEGEMENT) {
            return float.NaN;
        }

        return t;
    }

    public void Draw(float width, Color color) {
        Coords.DrawLine(a, b, width, color);
    }

    public Coords Lerp(float t) {

        if (lineType == LINETYPE.SEGEMENT) {
            t = Mathf.Clamp01(t);
        } else if (lineType == LINETYPE.RAY && t < 0)
            t = 0;

        float x = a.x + v.x * t;
        float y = a.y + v.y * t;
        float z = a.z + v.z * t;

        return new Coords(x, y, z);
    }
}
