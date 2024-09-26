using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int width = 20;
    public int height = 20;
    public GameObject snakeSegmentPrefab;
    public GameObject foodPrefab;
    private List<Transform> snake = new List<Transform>();
    private Vector2 direction;
    private Transform food;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}

