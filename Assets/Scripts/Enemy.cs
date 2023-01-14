using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{  
    // Enemy attributes
    private float mySpeed = 0.0f;
    public float Speed 
    {
        get { return mySpeed; }
        set 
        {
            if(value < 0) 
            { 
                Debug.Log("You can't set a negative speed!"); 
            }
            else 
            { 
                mySpeed = value; 
            }
        }
    }

    // Target variable
    private Transform target;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer() 
    {
        transform.position += GetDistanceFromPlayer() * mySpeed * Time.deltaTime;
        transform.LookAt(target);
    }

    private Vector3 GetDistanceFromPlayer()
    {
        return (target.transform.position - transform.position).normalized;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is hit!");
            Destroy(gameObject);
        }
    }
}
