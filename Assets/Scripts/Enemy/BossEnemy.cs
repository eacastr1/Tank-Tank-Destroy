using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : CarEnemy
{

    // Boss attack attributes
    [SerializeField] private GameObject missile;
    [SerializeField] private GameObject bomb;
    private float cooldown = 2.0f;

    // Missile attributes
    [SerializeField] private GameObject missileSpawn;
    [SerializeField] private GameObject bombSpawn;

    private OutOfBounds constraint;
    private bool outOfBounds = false;
    private bool newlySpawned = true;
    
    

    // Start is called before the first frame update
    void Start()
    {
        constraint = GetComponent<OutOfBounds>();
        transform.LookAt(target);
        // InvokeRepeating("LookAt", 0.0f, cooldown);
    }

    // Update is called once per frame
    void Update()
    {
        // RotateAroundCenter();
        // StartCoroutine("ShootMissile");
        LaunchAtPlayer();
    }

    // Look at player
    // Go in direction that BossEnemy is facing
    // Stop at the border of the screen
    void LaunchAtPlayer() 
    {   
        if(newlySpawned)
        {
            StartCoroutine(WaitAfterSpawn(8.0f));
            newlySpawned = false;
        }

        if(outOfBounds == false)
        {
            transform.Translate(Vector3.forward * 30.0f * Time.deltaTime);
            outOfBounds = constraint.CheckConstraints();
        } else {
            transform.Translate(Vector3.zero);
            StartCoroutine(CooldownAfterLaunch(cooldown));
        }
    }

    private IEnumerator CooldownAfterLaunch(float cooldown)
    {
        transform.LookAt(target);
        yield return new WaitForSeconds(cooldown);
        outOfBounds = false;
    }

    private IEnumerator WaitAfterSpawn(float time)
    {
        yield return new WaitForSeconds(time);
    }

    /*
    void RotateAroundCenter()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, 45.0f * Time.deltaTime);
        transform.LookAt(target);
    }

    void ShootMissile()
    {
        Instantiate(missile, missileSpawn.transform.position, transform.rotation);
    } 
    */
}
