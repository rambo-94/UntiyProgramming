using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //public GameObject[] RoadBlockprefabs;
    public GameObject[] carprefabs;
  
    public float startDelay = 2.0f;
    public float spawnInterval = 1.5f;
    public GameObject player;
    Transform t = null;

    
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("spawnRoadBlockPrefab", startDelay, spawnInterval);
        InvokeRepeating("SpawnCarPrefab", startDelay, spawnInterval);

        t = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    //void spawnRoadBlockPrefab()
    //{
        
    //    Debug.Log(t.position.z);
    //    int index = Random.Range(0, RoadBlockprefabs.Length);
    //    Vector3 spawnPos = new Vector3(Random.Range(-3, 3), 0, t.position.z +30);
    //    Instantiate(RoadBlockprefabs[index], spawnPos, RoadBlockprefabs[index].transform.rotation);
    //}

    void SpawnCarPrefab()
    {
        
        Debug.Log(t.position.z);
        int index = Random.Range(0, carprefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-3, 3), 0, t.position.z + 50);
        Instantiate(carprefabs[index], spawnPos, carprefabs[index].transform.rotation);
    }

}