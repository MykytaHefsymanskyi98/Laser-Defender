﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    Text scoreText;
    GameSession gameSession;
    


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
        ShowingScore();
    }

    // Update is called once per frame
    void Update()
    {
        ShowingScore();
    }

    public void ShowingScore()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
}
