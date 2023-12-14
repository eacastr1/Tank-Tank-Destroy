using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] protected float speed;

    // For user controlled movement
    protected void Move(float verticalInput)
    {
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
    }

    // For enemy movement
    protected void Move(Vector3 position)
    {
        transform.Translate(position * speed * Time.deltaTime);
    }
}
