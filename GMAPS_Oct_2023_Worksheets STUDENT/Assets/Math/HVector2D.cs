using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    public static HVector2D operator +( HVector2D vec1, HVector2D vec2)
    {
        return new HVector2D(vec1.x + vec2.x, vec1.y + vec2.y);
    }

    public static HVector2D operator -(HVector2D vec1 , HVector2D vec2)
    {
        return new HVector2D(vec1.x - vec2.x, vec1.y - vec2.y);
    }

    public static HVector2D operator *(HVector2D vec, float scalar)
    {
        return new HVector2D(vec.x * scalar, vec.y * scalar);
    }

    public static HVector2D operator /(HVector2D vec, float scalar)
    {
        return new HVector2D(vec.x / scalar, vec.y / scalar);
    }

    public float Magnitude()
    {
        
        return (float)Math.Sqrt(x * x + y * y);
    }

    public void Normalize()
    {
        float magnitude = Magnitude();
        x /= magnitude;
        y /= magnitude;
    }

    public float DotProduct(HVector2D target)
    {

        return ((normalized.x * target.normalized.x) + (normalized.y * target.normalized.y));
    }

    public HVector2D Projection(HVector2D target)
    {
        HVector2D projection = target * (DotProduct(target) / target.DotProduct(target));
        return projection;
    }

    public static float FindAngle(float dotProduct)
    {
        float angleRadian = Mathf.Acos(dotProduct);
        float angleDegree = angleRadian * Mathf.Rad2Deg;
        return (float)angleDegree;
    }

    public Vector2 ToUnityVector2()
    {
        return new(x,y); // change this
    }

    public Vector3 ToUnityVector3()
    {
        return new(x,y,0); // change this
    }

    public HVector2D normalized
    {
        get { return new HVector2D(x / Magnitude(), y / Magnitude()); }
    }

    // public void Print()
    // {

    // }
}
