using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
    private float[] values;
    private int rows;
    private int cols;

    public Matrix(int r, int c)
    {
        rows = r;
        cols = c;
    }

    public Matrix(int r, int c, float[] v)
    {
        rows = r;
        cols = c;
        values = new float[rows * cols];
        Array.Copy(v, values, rows * cols);
    }

    public Coords MatrixToCoords()
    {
        if (rows == 4 && cols == 1)
            return new Coords(values[0], values[1], values[2], values[3]);
        else
            return null;
    }

    public static Matrix operator+(Matrix m1, Matrix m2)
    {
        if (m1.rows != m2.rows || m1.cols != m2.cols)
            return null;

        Matrix m3 = new Matrix(m1.rows, m1.cols, m1.values);
        float length = m1.rows * m1.cols;
        for(int i = 0; i < length; i++)
        {
            m3.values[i] = m1.values[i] + m2.values[i];
        }

        return m3;
    }

    public static Matrix operator*(Matrix m1, Matrix m2)
    {
        if (m1.cols != m2.rows)
            return null;

        float[] resultVal = new float[m1.rows * m2.cols];
        for(int i = 0; i < m1.rows; i++)
        {
            for(int j = 0; j < m2.cols; j++)
            {
                for(int k = 0; k < m1.cols; k++)
                {
                    resultVal[i * m2.cols + j] += m1.values[i * m1.cols + k] * m2.values[k * m2.cols + j];
                }
            }
        }
        Matrix m3 = new Matrix(m1.rows, m2.cols, resultVal);
        return m3;
    }

    public override string ToString()
    {
        string matrix = "";

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                matrix += values[i * cols + j] + "\t";
            }
            matrix += "\n";
        }

        return matrix;
    }
}
