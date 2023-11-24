using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : Projectile
{
    [SerializeField] private float radius = 4.0f;
    
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        DetectTarget();
    }

    void HomeOnTarget()
    {
        Debug.Log("LOCKED ON");
        transform.position += (target.transform.position - transform.position).normalized * speed * Time.deltaTime;
        transform.LookAt(target);
    }

    void DetectTarget()
    {
        if(GetDistanceFromTarget() < radius)
        {
            HomeOnTarget();
        }
        else 
        {
            MoveForward();
        }
    }

    float GetDistanceFromTarget()
    {
        return Vector3.Distance(target.position, transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
