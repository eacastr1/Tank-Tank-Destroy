using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUp
{
    // PlayerController reference
    private PlayerController playerController;

    // Health Power Up attributes
    [SerializeField] private int livesToAdd = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public override void Power()
    {
        playerController.lives = livesToAdd;
        Debug.Log("Player Lives: " + playerController.lives);
    }
}
