using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane
{
    public Coords A;
    public Coords B;
    public Coords C;

    public Coords v;
    public Coords u;

    public Plane(Coords _a, Coords _b, Coords _c) {
        A = _a;
        B = _b;
        C = _c;

        v = B - A;
        u = C - A;
    }

    public Plane(Coords _a, Vector3 V, Vector3 U) {
        A = _a;
        v = new Coords(V.x, V.y, V.z);
        u = new Coords(U.x, U.y, U.z);
    }

    public Coords Lerp(float s, float t) {
        float x = A.x + (v.x * s) + (u.x * t);
        float y = A.y + (v.y * s) + (u.y * t);
        float z = A.z + (v.z * s) + (u.z * t);

        return new Coords(x, y, z);
    }

}
