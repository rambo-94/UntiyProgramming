﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    private float spawnRate = 1f;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {

       


    }

    public void UpdatedScore(int scoreToAdd)
    {


        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {


            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
          
        }


    }

    public void GameOver()

    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }


    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    

    }

    public void StartGame(int difficulty)
    {

        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdatedScore(0);
        titleScreen.gameObject.SetActive(false);

    }
}
