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

    private void CreateSnake()
    {
        Vector2Int startPosition = new Vector2Int(boardWidth / 2, boardHeight / 2);

        for (int i = 0; i < 3; i++)
        {

            Vector2Int position = startPosition - new Vector2Int(i, 0);
            AddSnakeSegment(position);
        }
    }

    private void AddSnakeSegment(Vector2Int position)
    {
        throw new NotImplementedException();
    }

    public void MoveSnake()
    {

        Vector2Int newPosition = Vector2Int.RoundToInt(snakeSegments[0].position) + currentDirection;

        if (CheckCollision(newPosition))
        {
            Debug.Log("Game Over!");

            return;
        }


        if (newPosition == foodPosition)
        {
            SpawnFood();
        }
        else
        {

            Destroy(snakeSegments[snakeSegments.Count - 1].gameObject);
            snakeSegments.RemoveAt(snakeSegments.Count - 1);
        }


        AddSnakeSegment(newPosition);
    }

    private bool CheckCollision(Vector2Int newPosition)
    {
        throw new NotImplementedException();
    }
}