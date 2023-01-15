using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : CarEnemy
{

    // Boss attack attributes
    [SerializeField] private GameObject missile;
    [SerializeField] private GameObject bomb;

    // Missile attributes
    [SerializeField] private GameObject missileSpawn;
    [SerializeField] private GameObject bombSpawn;


    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootMissile", 3.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        RotateAroundCenter();
        // StartCoroutine("ShootMissile");
    }

    void RotateAroundCenter()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, 45.0f * Time.deltaTime);
        transform.LookAt(target);
    }

    void ShootMissile()
    {
        Instantiate(missile, missileSpawn.transform.position, transform.rotation);
    }
}
