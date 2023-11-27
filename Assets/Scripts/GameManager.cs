using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    // UI attributes 
    private int score;
    private int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
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
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {

        if(!myGameOver)
        {
            // spawnManager.SpawnBoss();
            spawnManager.SpawnWave();
        }
    }

    public void UpdateScore(int scoreToAdd) 
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int livesToAdd)
    {
        lives = livesToAdd;
        livesText.text = "Lives: " + lives;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        myGameOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    
}
