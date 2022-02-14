using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathLib.Math;

public class Transformations : MonoBehaviour
{
    public GameObject[] points;
    public Transform centerPoint;
    public float angle;
    public Vector3 translates;
    public Vector3 scaling;

    private void Start()
    {
        Vector3 centerPos = new Vector3(centerPoint.position.x, centerPoint.position.y, centerPoint.position.z);
        Debug.Log("Center Pos : " + centerPos);
        foreach(GameObject point in points)
        {
            Coords position = new Coords(point.transform.position, 1);

            position = MyMath.Translate(position, new Coords(-centerPos, 0));
            position = MyMath.Scale(position, new Coords(scaling));
            point.transform.position = MyMath.Translate(position, new Coords(centerPos, 0)).ToVector();
        }

    }
}
