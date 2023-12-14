using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player Vehicle Script
    [SerializeField] PlayerVehicle vehicle;
    // Game attributes
    [SerializeField] GameManager gameManager;
    [SerializeField] ShellPoolManager shellPoolManager;
    // Player attributes
    [SerializeField] AudioSource playerAudio;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AimController aimController;
    // Player life attributes
    [SerializeField] int myLives = 3;
    public int lives
    {
        get { return myLives; }
        set
        {
            if(value < 0)
            {
                Debug.Log("You can't have negative lives");
            }
            else if(value > 3)
            {
                Debug.Log("You can't have more than 3 lives");
            }
            else
            {
                myLives = value;
            }
        }
    }
    public bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
        aimController = GetComponent<AimController>();
        vehicle = GetComponent<PlayerVehicle>();
    }

    // Update is called once per frame
    void Update()
    {
        if(LifeCheck() == false)
        {
            aimController.Aim();
            Shoot();
            ControlVehicle();   
            gameManager.UpdateLives(myLives);
        } else {
            gameManager.GameOver();
        }
    }

    private void ControlVehicle() 
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        vehicle.MoveForward(verticalInput);
        vehicle.Rotate(horizontalInput);
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAudio.PlayOneShot(shootSound);
            GameObject shell = vehicle.GetShell(aimController.GetCannonRotation());
        }
    }

    private bool LifeCheck()
    {
        if(isHit)
        {  
            lives--;
            isHit = false;
            Debug.Log("Player Lives: " + lives);
        }
        if(lives == 0)
        {
            gameManager.gameOver = true;
        }

        return gameManager.gameOver;
    }
}
