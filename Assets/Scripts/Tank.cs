using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathLib.Math;

public class Tank : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private void Update() {
        float translatation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
         
        translatation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.position = MyMath.Translate(new Coords(transform.position), 
            new Coords(0, translatation, 0), new Coords(transform.up)).ToVector();
        transform.up = MyMath.Rotate(new Coords(transform.up), rotation * Mathf.PI / 180, true).ToVector();
    }
}
