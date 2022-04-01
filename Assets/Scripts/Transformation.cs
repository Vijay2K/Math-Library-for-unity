using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathLib.Math;

public class Transformation : MonoBehaviour
{
    public GameObject[] points;
    public GameObject centerPoint;

    public bool isTranslate;
    public bool isScaling;

    public Vector3 translation;
    public Vector3 scaling;

    private void Start()
    {
        Vector3 centerPos = centerPoint.transform.position;

        foreach(GameObject point in points)
        {
            Coords pos = new Coords(point.transform.position, 1);

            if(isTranslate)
            {
                point.transform.position = MyMath.Translate(pos, new Coords(translation, 0)).ToVector();
            }

            if(isScaling)
            {
                pos = MyMath.Translate(pos, new Coords(centerPos * -1, 0));
                pos = MyMath.Scale(pos, new Coords(scaling));
                point.transform.position = MyMath.Translate(pos, new Coords(centerPos, 0)).ToVector();
            }
        }
    }
}
