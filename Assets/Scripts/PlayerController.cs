using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Game attributes
    private GameManager gameManager;
    // Player life attributes
    private int myLives = 3;
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
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        aimController = GetComponent<AimController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(LifeCheck() == false)
        {
            aimController.Aim();
            Shoot();
            Move();   
        }
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
