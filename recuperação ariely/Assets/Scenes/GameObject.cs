using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject : MonoBehaviour
{
    public static GameManager Instance { get; private set; } 

    public GameObject snakeSegmentPrefab;  
    public GameObject foodPrefab;  

    public int boardWidth = 20;    
    public int boardHeight = 20;   

    private List<Transform> snakeSegments = new List<Transform>(); 
    private Vector2Int currentDirection;  
    private Transform foodInstance;  

    private Vector2Int foodPosition;

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

    
    private void InitializeGame()
    {
        currentDirection = Vector2Int.right; 
        CreateSnake();  
        SpawnFood();    
    }

    private void SpawnFood()
    {
        throw new NotImplementedException();
    }

    private void CreateSnake()
    {
        throw new NotImplementedException();
    }
}
