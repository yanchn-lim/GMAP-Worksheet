using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    HMatrix2D mat = new();
    HMatrix2D mat1 = new(1, 2, 6, 2, 3, 7, 3,5,1);
    HMatrix2D mat2 = new(5, 2, 7, 8, 6, 5, 4, 6,5);
    HVector2D vec = new(5, 3);
    // Start is called before the first frame update
    void Start()
    {
        Question1();
        Question2();
    }

    void Question1()
    {
        mat.SetIdentity();
        mat.Print();
    }

    void Question2()
    {
        HMatrix2D result = mat1 * mat2;
        HVector2D res = mat1 * vec;

        Debug.Log($"{res.x}, {res.y}");

        result.Print();

        result.SetTranslationMat(1,1);
        result.Print();

        result.SetRotationMat(1);
        result.Print();
        //Debug.Log($"{res.x}  ,{res.y}");
    }
}
