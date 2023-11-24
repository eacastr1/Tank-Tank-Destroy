using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed;

    protected void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
