using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float speed = 10;
    private GameObject focalPoint;
    private Rigidbody playerRb;
    public bool hasPowerUp = false;
    private float powerupStrength = 15;
    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerUpIndicator.transform.position = transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PowerUp"))
        {

            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
            Destroy(other.gameObject);
        }

    }

    IEnumerator PowerupCountdownRoutine()
    {


        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {

            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with" + collision.gameObject.name +"with PowerUp set to "+ hasPowerUp);
            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

        }

    }
}