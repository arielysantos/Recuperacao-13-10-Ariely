using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gameOverText;

    private int score = 0;
    private int highScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "SCORE: " + score;
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "HIGH SCORE: " + highScore;
        }
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "SCORE: " + score;
    }

    public void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public void HideGameOver()
    {
        gameOverText.gameObject.SetActive(false);
    }

    internal void Restart()
    {
        throw new NotImplementedException();
    }

    internal void GameOver()
    {
        throw new NotImplementedException();
    }

    public static implicit operator GameManager(GameObject v)
    {
        throw new NotImplementedException();
    }
}
