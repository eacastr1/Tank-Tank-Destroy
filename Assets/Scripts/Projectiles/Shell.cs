using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : Projectile
{
    // Update is called once per frame
    void Update()
    {
        if(!gameObject.GetComponent<OutOfBounds>().CheckConstraints())
        {
            MoveForward();
        }
        else 
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            // other.gameObject.Enemy.Death();(?)
        }
    }
}
