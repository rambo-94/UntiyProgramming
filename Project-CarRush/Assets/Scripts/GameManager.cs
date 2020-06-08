using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    private int score;
 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive=false;
    public GameObject titleScreen;
    public GameObject[] carprefabs;
    public float startDelay = 2.0f;
    public float spawnInterval = 1.5f;
    public GameObject player;
    Transform t = null;
   

    // Start is called before the first frame update
    void Start()
    {

        t = player.GetComponent<Transform>();
        isGameActive = false;

    }


    public void UpdatedScore(double scoreToAdd)
    {


        scoreToAdd = scoreToAdd * 10;
        scoreText.text = "Score:" + scoreToAdd;
    }

    // Update is called once per frame
    void Update()
    {

       

    }


    //IEnumerator SpawnTarget()
    //{
    //    while (isGameActive)
    //    {


    //        yield return new WaitForSeconds(spawnRate);
    //        int index = Random.Range(0, targets.Count);
    //        Instantiate(targets[index]);

    //    }


    //}

    public void GameOver()

    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        
    }


    public void RestartGame()
    {
        Debug.Log("fds");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }


    IEnumerator SpawnTargetz()
    {
        while (isGameActive)
        {


            yield return new WaitForSeconds(1);
            Debug.Log(t.position.z);
            int index = UnityEngine.Random.Range(0, carprefabs.Length);
            Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(583, 598), 184, t.position.z + 50);
            Instantiate(carprefabs[index], spawnPos, carprefabs[index].transform.rotation);

        }



    }

    public void StartGame()
    {
        Debug.Log("start");
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTargetz());
        UpdatedScore(0);
        
        .gameObject.SetActive(false);

    }

    
}