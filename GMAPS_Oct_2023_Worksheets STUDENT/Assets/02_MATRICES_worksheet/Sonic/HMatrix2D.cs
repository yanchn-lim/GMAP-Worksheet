// Uncomment this whole file.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    //creating a multidimensional array
    public float[,] entries { get; set; } = new float[3, 3];

    //instancing the matrix without any parameter should just create an identity matrix
    public HMatrix2D()
    {
        SetIdentity();
    }

    //setting our multi-dimensional array "entries" with the one inputted in the parameters
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

    //setting each entries in our multi-dimensional array
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

    //overloading the + operator for our matrix class
    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D newMatrix = new();

        //loops through the 2 dimensions of the arrays and adds up each entries
        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int j = 0; j < left.entries.GetLength(1); j++)
            {
                newMatrix.entries[i, j] = left.entries[i, j] + right.entries[i, j];
            }
        }

        return newMatrix;
    }

    //overloading the - operator for our matrix class
    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D newMatrix = new();

        //loops through the 2 dimensions of the arrays and subtracts each entries
        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int j = 0; j < left.entries.GetLength(1); j++)
            {
                newMatrix.entries[i, j] = left.entries[i, j] - right.entries[i, j];
            }
        }

        return newMatrix;
    }

    //overloading the * operator for our matrix class
    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D newMatrix = new();

        //loops through our entries and multiply them with the scalar
        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int j = 0; j < left.entries.GetLength(1); j++)
            {
                newMatrix.entries[i, j] *= left.entries[i, j] * scalar;

            }
        }

        return newMatrix;
    }

    // Note that the second argument is a HVector2D object
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        //doing matrix multiplication for our 3x3 and the 3x1 vector
        
        return new HVector2D(
                left.entries[0,0] * right.x + left.entries[0,1] * right.y + left.entries[0,2] * right.h,
                left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1, 2] * right.h
            );
    }

    // Note that the second argument is a HMatrix2D object
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        //doing matrix multiplication for 3x3 and 3x3 matrices
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


    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {

        //loops through the matrices' entries and compare them to see if they are the same
        //if any entry is different then it would return false
        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int j = 0; i < left.entries.GetLength(1); i++)
            {
                if (left.entries[i, j] != right.entries[i, j])
                    return false;
            }
        }

        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        //loops through the matrices' entries and compare them to see if they are different
        //if any entry is different then it would return false
        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int j = 0; i < left.entries.GetLength(1); i++)
            {
                if (left.entries[i, j] == right.entries[i, j])
                    return false;
            }
        }

        return true;
    }

    //public HMatrix2D transpose()
    //{
    //    return // your code here
    //}

    //public float GetDeterminant()
    //{
    //    return // your code here
    //}

    public void SetIdentity()
    {

        //goes through the entries and set 1 to the diagonal of the matrix
        for (int y = 0; y < entries.GetLength(1); y++)
        {
            for (int x = 0; x < entries.GetLength(0); x++)
            {

                entries[x, y] = x == y ? 1 : 0;
            }
        }
    }

    public void SetTranslationMat(float transX, float transY)
    {
        //set identity first
        SetIdentity();

        //places the translation entries in their respective positions
        entries[0, 2] = transX;
        entries[1, 2] = transY;
    }

    public void SetRotationMat(float rotDeg)
    {
        //set identity first
        SetIdentity();

        //convert the input which is in degree to radian
        float rad = rotDeg * Mathf.Rad2Deg;

        //set the rotation 
        entries[0, 0] = Mathf.Cos(rad);
        entries[0, 1] = -Mathf.Sin(rad);
        entries[1, 0] = Mathf.Sin(rad);
        entries[1, 1] = Mathf.Cos(rad);
    }

    public void SetScalingMat(float scaleX, float scaleY)
    {
        //set identity first
        SetIdentity();

        //set the scaling matrix in their respective entries
        entries[0, 0] *= scaleX;
        entries[1, 1] *= scaleY;
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
