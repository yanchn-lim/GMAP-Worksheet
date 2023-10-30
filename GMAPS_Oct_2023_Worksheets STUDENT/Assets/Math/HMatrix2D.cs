using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        // your code here
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int i = 0; i < entries.GetLength(0); i++)
        {
            for (int k = 0; k < entries.GetLength(1); k++)
            {
                entries[i, k] = multiArray[i, k];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        //first row
        entries[0, 0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;

        // Second row
        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;

        // Third row
        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;

    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D newMatrix = new();
        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int j = 0; j < left.entries.GetLength(1); j++)
            {
                newMatrix.entries[i, j] = left.entries[i, j] + right.entries[i, j];
            }
        }

        return newMatrix;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D newMatrix = new();
        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int j = 0; j < left.entries.GetLength(1); j++)
            {
                newMatrix.entries[i, j] = left.entries[i, j] - right.entries[i, j];
            }
        }

        return newMatrix;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D newMatrix = new();
        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int j = 0; j < left.entries.GetLength(1); j++)
            {
                newMatrix.entries[i,j] *= left.entries[i,j]*scalar;

            }
        }

        return newMatrix;
    }

    // Note that the second argument is a HVector2D object
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        HVector2D result = new();
        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            float r = 0;
            for (int j = 0; j < left.entries.GetLength(1); j++)
            {
                if (j == 0)
                    r += right.x * left.entries[i, j];

                if (j == 1)
                    r += right.y * left.entries[i, j];

                if (j == 2)
                    r += right.h * left.entries[i, j];
            }
            if (i == 0)
                result.x = r;

            if (i == 1)
                result.y = r;
        }
        return result;
    }

    
    // Note that the second argument is a HMatrix2D object
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],
            left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],
            left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],

            left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],
            left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],
            left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],

            left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],
            left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],
            left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]
    );
    }
    /*
    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int k = 0; k < left.entries.GetLength(1); k++)
            {
                if (left.entries[i, k] != right.entries[i, k])
                    return false;
            }
        }

        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int k = 0; k < left.entries.GetLength(1); k++)
            {
                if (left.entries[i, k] != right.entries[i, k])
                    return true;
            }
        }
        return false;
    }
    
    
    public override bool Equals(object obj)
    {
        // your code here
    }
    */
    //public override int GetHashCode()
    //{
    //    // your code here
    //}

    
    public HMatrix2D transpose()
    {
        return // your code here
    }

    public float getDeterminant()
    {
        return // your code here
    }
    
    public void setIdentity()
    {
        for (int y = 0; y < entries.GetLength(1); y++)
        {
            for (int x = 0; x < entries.GetLength(0); x++)
            {

                entries[x, y] = x == y ? 1 : 0;
            }
        }
    }

    public void setTranslationMat(float transX, float transY)
    {
        // your code here
    }

    public void setRotationMat(float rotDeg)
    {
        setIdentity();
        float rad = rotDeg * Mathf.Rad2Deg;
        entries[0,0] = 
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        // your code here
    }
    
    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}