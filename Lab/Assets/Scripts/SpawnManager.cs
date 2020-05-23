using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemys;
    public GameObject powerup;


    private float zspawnEnemy = 12.0f;
    private float xSpawnRange = 12.0f;
    private float ZpowerRange = 5.0f;
    private float yspawn = 0.75f;

    private float powerUpSpawnTIme = 5.0f;

    private float EnemySpawnTime = 1.0f;

    private float SpawnDelay = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawnenemy", SpawnDelay, EnemySpawnTime);
        InvokeRepeating("SpawnPowerup", SpawnDelay, powerUpSpawnTIme);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawnenemy()
    {
        float randomx = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemys.Length);
        Vector3 spawnPos = new Vector3(randomx, yspawn, zspawnEnemy);
        Instantiate(enemys[randomIndex], spawnPos, enemys[randomIndex].gameObject.transform.rotation);
    }

    void SpawnPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-ZpowerRange, ZpowerRange);
        Vector3 spawnPos = new Vector3(randomX, yspawn, randomZ);
        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);

    }
}