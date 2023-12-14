using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private int xRange = 45;
    private int zRange = 25;

    public bool CheckConstraints()
    {
        if(transform.position.z > zRange)
        {
            return true;
        }
        else if(transform.position.z < -zRange)
        {
            return true;
        }
        if(transform.position.x > xRange)
        {
            return true;
        }
        else if(transform.position.x < -xRange)
        {
            return true;
        }

        return false;
    }
}
