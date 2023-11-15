using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        HVector2D result = p1 - p2;
        float resultDist = result.Magnitude();
        return resultDist;
    }
}

