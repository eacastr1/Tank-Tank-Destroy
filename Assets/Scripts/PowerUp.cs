using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] private float spinSpeed;
    void Update()
    {
        Spin();
    }

    public abstract void Power();

    void Spin() 
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Power();
            Destroy(gameObject);
        }
    }
}
