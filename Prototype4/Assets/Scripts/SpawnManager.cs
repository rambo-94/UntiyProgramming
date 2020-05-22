using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spwanRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {


        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber += 1;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);

        }

    }

    private void SpawnEnemyWave(int enemy)
    {
        for (int i = 0; i < enemy; i++)
        {
            
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }



    }

    public Vector3 GenerateSpawnPos()
    {


        float spawnPosX = Random.Range(-spwanRange, spwanRange);
        float spwanPosZ = Random.Range(-spwanRange, spwanRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spwanPosZ);
        return randomPos;
    }
}
