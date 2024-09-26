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

    private bool IsPositionOccupied(Vector2 position)
    {
        throw new NotImplementedException();
    }

    public void ChangeDirection(Vector2 newDirection)
    {
        if (newDirection != -direction) // Impede movimento reverso
            direction = newDirection;
    }


    public void MoveSnake()
    {
        Vector2 newPosition = (Vector2)snake[0].position + direction;
        if (CheckCollision(newPosition))
        {
            Debug.Log("Game Over!");
            return; // Finaliza o jogo
        }
        Transform newSegment = Instantiate(snakeSegmentPrefab, newPosition, Quaternion.identity).transform;
        snake.Insert(0, newSegment);
        if (newPosition == (Vector2)food.position)
        {
            SpawnFood(); // Comeu a comida
        }
        else
        {
            Destroy(snake[snake.Count - 1].gameObject); // Remove a cauda
            snake.RemoveAt(snake.Count - 1);
        }
    }

    private bool CheckCollision(Vector2 position)
    {
        if (position.x < 0 || position.x >= width || position.y < 0 || position.y >= height)
            return true; // Colisão com as bordas
        foreach (var segment in snake)
        {
            if (segment.position == (Vector3)position) return true; // Colisão com o corpo
        }
        return false;
    }
}
