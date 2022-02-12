using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    Line l1;
    Line l2;

    private void Start() {
        l1 = new Line(new Coords(-100, 0, 0), new Coords(20, 50, 0));
        l1.Draw(1, Color.green);
        l2 = new Line(new Coords(-100, 10, 0), new Coords(0, 50, 0));
        l2.Draw(1, Color.red);

        float intersectT = l1.IntersectionAt(l2);
        float intersectS = l2.IntersectionAt(l1);

        if(intersectT == intersectT && intersectS == intersectS) {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = l1.Lerp(intersectT).ToVector();
            sphere.transform.localScale = Vector3.one * 5;
        }

        Debug.Log("T : " + intersectT + " and S : " + intersectS);
    }
}
