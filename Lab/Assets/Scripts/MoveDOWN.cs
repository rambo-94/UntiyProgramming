using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDOWN : MonoBehaviour
{
    public float speed = 15.0f;
    private Rigidbody objectRb;
    private float zboundry = -5.5f;

    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward * -speed);

        if (transform.position.z < zboundry)
        {
            Destroy(gameObject);
        }
    }
}