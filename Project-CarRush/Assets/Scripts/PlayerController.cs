using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed = 25.0f;
    public float speed = 15.0f;
    public float horizontalInput;
    public float forwardInput;
    private GameManager gameManager;
    public GameObject winner;
    public TMPro.TextMeshProUGUI scoreText;
    public float initial = 510;
    public float x;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

        x=transform.position.z - initial;
        x = x / 107;
        Debug.Log(Math.Floor(x));
        gameManager.UpdatedScore(Math.Floor(x));
        if (transform.position.z > 1477)
        {
            gameManager.GameOver();
            winner.gameObject.SetActive(true);

        }
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        //Move the vehicle forward
        if (forwardInput != 0)
        {
            speed = 40f;


        }
        if (gameManager.isGameActive == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            if (transform.position.x < 582)
            {
                transform.position = new Vector3(582, transform.position.y, transform.position.z);
            }

            if (transform.position.x > 600)
            {
                transform.position = new Vector3(600, transform.position.y, transform.position.z);

            }
                

        }
    }

    
        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Enemy"))
            {

                Debug.Log("yyy");
                gameManager.GameOver();
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                Destroy(other.gameObject);
               

        }

        
        }

    public void RestartGame()
    {
        Debug.Log("fds");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
}
