using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player movement attributes
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    // Player aiming reference
    private AimController aimController;

    // Player shooting variables
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        aimController = GetComponent<AimController>();
    }

    // Update is called once per frame
    void Update()
    {
        aimController.Aim();
        Shoot();
        Move();
    }

    private void Move() 
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bulletPrefab, bulletSpawn.position, aimController.GetCannonRotation());
        }
    }
}
