using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathLib.Math;

public class Transformations : MonoBehaviour
{
    public GameObject[] points;
    public float angle;
    public Vector3 translates;

    private void Start()
    {
        /*        Coords position = new Coords(point.transform.position, 1);
                point.transform.position = MyMath.Translate(position, new Coords(translate, 0)).ToVector();*/

        Coords[] positions = new Coords[points.Length];
        for(int i = 0; i < points.Length; i++)
        {
            positions[i] = new Coords(points[i].transform.position, 1);
            points[i].transform.position = MyMath.Translate(positions[i], new Coords(translates, 0)).ToVector();
        }

    }
}
