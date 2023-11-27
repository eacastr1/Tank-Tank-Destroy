using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{  
    public ParticleSystem explosionParticle;

    public AudioSource enemyAudio;
    public AudioClip deathSound;
    public AudioClip crashSound;

    // Enemy attributes
    private bool isDead = false;
    private float mySpeed = 0.0f;
    public float Speed 
    {
        get { return mySpeed; }
        set 
        {
            if(value < 0) 
            { 
                Debug.Log("You can't set a negative speed!"); 
            }
            else 
            { 
                mySpeed = value; 
            }
        }
    }

    // Target variables
    protected PlayerController playerController;
    protected Transform target;

    // Start is called before the first frame update
    void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        target = GameObject.Find("Player").transform;
        //enemyAudio = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    void OnEnable()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false) {
            FollowPlayer();
        }
    }

    private void FollowPlayer() 
    {
        transform.position += GetDistanceFromPlayer() * mySpeed * Time.deltaTime;
        transform.LookAt(target);
    }

    private Vector3 GetDistanceFromPlayer()
    {
        return (target.transform.position - transform.position).normalized;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player") && isDead == false)
        {
            Death();
            enemyAudio.PlayOneShot(crashSound);
            playerController.isHit = true;
            Debug.Log("Player is hit!");
        }
    }

    public void Death()
    {
        // enemyAudio.PlayOneShot(deathSound);
        explosionParticle.Play();

        // Delay the deactivation by the length of the audio clip
        float delay = 1.0f; // Assuming deathSound is the AudioClip
        StartCoroutine(DeactivateAfterDelay(delay));
    }

    public void Respawn()
    {
        isDead = true;
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        isDead = true;
        yield return new WaitForSeconds(delay);
        // Deactivate the enemy after the delay
        gameObject.SetActive(false);
    }
}
