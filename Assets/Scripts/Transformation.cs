using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathLib.Math;

public class Transformation : MonoBehaviour
{
    public GameObject[] points;
    public Vector3 translation;

    private void Start()
    {
        foreach(GameObject point in points)
        {
            Coords pos = new Coords(point.transform.position, 1);
            point.transform.position = MyMath.Translate(pos, new Coords(translation, 0)).ToVector();
        }
    }
}
