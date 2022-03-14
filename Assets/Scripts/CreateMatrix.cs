using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMatrix : MonoBehaviour
{
    void Start()
    {
        Matrix m1 = new Matrix(2, 2, new float[] { 2, 4, 2, 6 });
        Matrix m2 = new Matrix(2, 2, new float[] { 1, 3, 2, 4 });

        Matrix m3 = new Matrix(3, 2, new float[] { 1, 2, 3, 4, 5, 6 });
        Matrix m4 = new Matrix(2, 4, new float[] { 1, 2, 3, 4, 5, 6, 7, 8 });

        Matrix addMatrix = m1 + m2;
        Matrix multiplyMatrix = m3 * m4;

        Debug.Log("Add : \n" + addMatrix.ToString());
        Debug.Log("Multiply : \n" + multiplyMatrix.ToString());
    }
}
