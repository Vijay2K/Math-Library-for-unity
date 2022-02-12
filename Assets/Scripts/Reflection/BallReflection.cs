using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathLib.Math;

public class BallReflection : MonoBehaviour
{
    [Header("Plane Points")]
    public Transform A_Plane;
    public Transform B_Plane;
    public Transform C_Plane;

    [Header("Line Points")]
    public Transform A_Line;
    public Transform B_Line;

    [Header("Gameobject reference")]
    public Transform ball;

    private Plane plane;
    private Line line;
    private Line trajectory;

    private void Start()
    {
        plane = new Plane(new Coords(A_Plane.position), new Coords(B_Plane.position), new Coords(C_Plane.position));
        line = new Line(new Coords(A_Line.position), new Coords(B_Line.position), Line.LINETYPE.SEGEMENT);

        for(float s = 0; s <= 1; s += 0.1f)
        {
            for(float t = 0; t <= 1; t += 0.1f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = plane.Lerp(s, t).ToVector();
                sphere.transform.localScale = Vector3.one * .5f;
                sphere.GetComponent<Renderer>().material.color = Color.cyan;
            }
        }

        line.Draw(0.5f, Color.red);

        float intersectT = line.IntersectionAt(plane);

        ball.position = line.a.ToVector();

        if(intersectT == intersectT)
        {
            trajectory = new Line(line.a, line.Lerp(intersectT), Line.LINETYPE.SEGEMENT);
        }

    }

    private void Update()
    {
        if (Time.time <= 1)
            ball.position = trajectory.Lerp(Time.time).ToVector();
        else
            ball.position += trajectory.Reflect(MyMath.CrossProduct(plane.v, plane.u)).ToVector() * Time.deltaTime * 10;
    }
}
