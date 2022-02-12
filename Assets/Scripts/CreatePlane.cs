using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlane : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;

    private Plane plane;

    private void Start() {
        plane = new Plane(new Coords(A.position), new Coords(B.position), new Coords(C.position));

        for(float s = 0; s < 1; s += 0.1f) {
            for(float t = 0; t < 1; t += 0.1f) {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = plane.Lerp(s, t).ToVector();
                sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        } 
    }
}
