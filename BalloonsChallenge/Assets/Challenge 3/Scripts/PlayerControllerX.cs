using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver=false;

    public float floatForce=5;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    private Transform location;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public bool isLowEnough = true;
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb=GetComponent<Rigidbody>();
        location = GetComponent<Transform>();
        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {

        // While space is pressed and player is low enough, float up
        Debug.Log(transform.position.y);
        if (transform.position.y < 13)
        {
            isLowEnough = true;

        }
        else {
            isLowEnough = false;
        }
        if (Input.GetKey(KeyCode.Space) && !gameOver && isLowEnough)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
        if(transform.position.y < 0.7)
        {
            playerRb.AddForce(Vector3.up * floatForce);


        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("zzzzz!");

            playerRb.AddForce(Vector3.up * floatForce);

        }



    }
}
