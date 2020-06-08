﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    private Button button;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        Debug.Log("button");
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetDifficulty()
    {


        Debug.Log(button.gameObject.name + "was clicked");
        gameManager.StartGame();
    }
}