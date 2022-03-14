using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
    private float[] values;
    private int rows;
    private int cols;

    public Matrix(int rows, int cols, float[] v)
    {
        this.rows = rows;
        this.cols = cols;
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

    #region OPERATOR OVERLOADING
    
    public static Matrix operator+ (Matrix m1, Matrix m2)
    {
        if (m1.rows != m2.rows || m1.cols != m2.cols)
            return null;

        Matrix resultMatrix = new Matrix(m1.rows, m1.cols, m1.values);

        int length = m1.rows * m2.cols;
        for (int i = 0; i < length; i++)
        {
            resultMatrix.values[i] += m2.values[i];
        }

        return resultMatrix;
    }

    public static Matrix operator- (Matrix m1, Matrix m2)
    {
        if (m1.rows != m2.rows || m1.cols != m2.cols)
            return null;

        Matrix resultMatrix = new Matrix(m1.rows, m1.cols, m1.values);
        int length = m1.rows * m1.cols;

        for(int i = 0; i < length; i++)
        {
            resultMatrix.values[i] += m2.values[i];
        }

        return resultMatrix;
    }    

    public static Matrix operator* (Matrix m1, Matrix m2)
    {
        if (m1.cols != m2.rows)
            return null;

        int length = m1.rows * m2.cols;

        float[] resultvalues = new float[length];

        for(int i = 0; i < m1.rows; i++)
        {
            for(int j = 0; j < m2.cols; j++)
            {
                for(int k = 0; k < m1.cols; k++)
                {
                    resultvalues[i * m2.cols + j] += m1.values[i * m1.cols + k] * m2.values[k * m2.cols + j];
                }
            }
        }   

        Matrix resultMatrix = new Matrix(m1.rows, m2.cols, resultvalues);

        return resultMatrix;
    }

    #endregion

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
