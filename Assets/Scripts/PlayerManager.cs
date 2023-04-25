﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static float playerHealth, currentScore;
    public Image healthImg;
    public TMP_Text scoreText, highScoreText;
    public GameObject gameON, gameOFF, enemies;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score = " + PlayerPrefs.GetFloat("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0)
           GameOver();
        healthImg.fillAmount = playerHealth;
        scoreText.text = currentScore.ToString();        
    }

    public void GameStart(){
        gameON.SetActive(true);
        gameOFF.SetActive(false);
        playerHealth = 1;
        currentScore = 0;
        scoreText.text = "0";
    }

    public void GameOver(){
        if(currentScore>PlayerPrefs.GetFloat("HighScore")){
        PlayerPrefs.SetFloat("HighScore", currentScore);
        highScoreText.text = "High Score = " + PlayerPrefs.GetFloat("HighScore").ToString();
        }
        foreach (Transform child in enemies.transform)
            child.gameObject.GetComponent<EnemyController>().Death();
        gameON.SetActive(false);
        gameOFF.SetActive(true);
    }
}
