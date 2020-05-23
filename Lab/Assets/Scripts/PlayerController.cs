using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 50.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;
    private float xRange = 15.0f;
    private float zRange = 9.5f;
    private float negativeZRange = 5.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        //move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //turn the player
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        if (transform.position.z < -negativeZRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -negativeZRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enenmy"))
        {
            Debug.Log("player has collided with enemy");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}