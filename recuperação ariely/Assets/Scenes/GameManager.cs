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

    private void InitializeGame()
    {
        throw new NotImplementedException();
    }

    private void SpawnSnake()
    {
        for (int i = 0; i < 3; i++)
        {
            AddSnakeSegment(new Vector2(i, 0));
        }
    }

    private void AddSnakeSegment(Vector2 vector2)
    {
        throw new NotImplementedException();
    }

    private void SpawnFood()
    {
        if (food != null) Destroy(food.gameObject);
        Vector2 position;
        do
        {
            position = new Vector2(UnityEngine.Random.Range(0, width), UnityEngine.Random.Range(0, height));
        } while (IsPositionOccupied(position));
        food = Instantiate(foodPrefab, position, Quaternion.identity).transform;
    }
}

