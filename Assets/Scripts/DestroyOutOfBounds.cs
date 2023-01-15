using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private int xRange = 45;
    private int zRange = 45;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckConstraints())
        {
            Destroy(gameObject);
        }
    }

    private bool CheckConstraints()
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
