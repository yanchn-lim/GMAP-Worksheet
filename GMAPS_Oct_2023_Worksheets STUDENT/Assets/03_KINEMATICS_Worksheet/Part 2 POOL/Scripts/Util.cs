using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        //find the direction vector from p1 to p2
        HVector2D result = p1 - p2;
        //resulting magnitude of the vector would be the distance
        float resultDist = result.Magnitude();
        return resultDist;
    }
}

