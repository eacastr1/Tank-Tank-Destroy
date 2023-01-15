using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game attributes
    private bool myGameOver;
    public bool gameOver
    {
        get { return myGameOver; }
        set 
        {
            myGameOver = value;
        }
    }
    // Spawn reference
    private SpawnManager spawnManager;

    // Player referece
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!myGameOver)
        {
            spawnManager.SpawnWave();
        }
    }

    void StartGame()
    {

    }

    void GameOver()
    {
        
    }
    
}
