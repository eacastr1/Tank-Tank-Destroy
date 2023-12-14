using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVehicle : Vehicle
{
    [SerializeField] float turnSpeed;
    [SerializeField] Transform shellSpawn; // Spawn location for tank shells.
    private ShellPoolManager shellPool;// Object pool for tank shells.

    void Start()
    {
        shellPool = ShellPoolManager.Instance;
    }

    public void MoveForward(float verticalInput)
    {
        Move(verticalInput);
    }

    public void Rotate(float horizontalInput)
    {
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
    
    public GameObject GetShell(Quaternion rotation)
    {
        return shellPool.GetShell(shellSpawn.position, rotation);
    }
}
