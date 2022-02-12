using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMatrix : MonoBehaviour
{
    Matrix m1, m2, m3;

    private void Start()
    {
        float[] values = { 1, 2, 3, 4, 5, 6 };
        float[] v2 = { 1, 2, 3, 4, 5, 6 };

        m1 = new Matrix(2, 3, values);
        m2 = new Matrix(3, 2, v2);

        m3 = m1 * m2;

        Debug.Log(m1.ToString());
        Debug.Log(m2.ToString());
        Debug.Log("Ans : \n");
        Debug.Log(m3.ToString());
        
    }
}
