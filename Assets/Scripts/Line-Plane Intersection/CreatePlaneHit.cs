using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlaneHit : MonoBehaviour
{
    [Header("Plane Points")]
    public Transform A_Plane;
    public Transform B_Plane;
    public Transform C_Plane;

    [Header("Line Points")]
    public Transform A_Line;
    public Transform B_line;

    private Plane plane;
    private Line line;

    private void Start()
    {
        plane = new Plane(new Coords(A_Plane.position), new Coords(B_Plane.position), new Coords(C_Plane.position));
        line = new Line(new Coords(A_Line.position), new Coords(B_line.position), Line.LINETYPE.SEGEMENT);

        line.Draw(0.5f, Color.red);
        for(float s = 0; s <= 1; s += 0.1f)
        {
            for(float t = 0; t <= 1; t += 0.1f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = plane.Lerp(s, t).ToVector();
                sphere.transform.localScale = Vector3.one * 0.5f;
                sphere.GetComponent<Renderer>().material.color = Color.cyan;
            }
        }

        float intersectT = line.IntersectionAt(plane);
        if(intersectT == intersectT)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = line.Lerp(intersectT).ToVector();
            cube.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
