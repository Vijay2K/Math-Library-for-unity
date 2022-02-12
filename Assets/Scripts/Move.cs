using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vijay.Math;

public class Move : MonoBehaviour
{
    public float speed;
    public Transform A;
    public Transform B;

    private float timer;

    private void Update() {
        transform.position = MyMath.Lerp(new Coords(A.position), new Coords(B.position), Time.time * speed).ToVector();
    }
}
