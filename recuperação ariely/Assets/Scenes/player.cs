using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public Vector2Int gridPosition; 
    public float moveTimerMax = 0.3f; 
    private float moveTimer;
    private Vector2Int direction; 
    private List<Transform> snakeSegments;
    public Transform segmentPrefab; 

    private void Start()
    {
        gridPosition = new Vector2Int(10, 10); 
        moveTimer = moveTimerMax;
        direction = Vector2Int.right; 
        snakeSegments = new List<Transform>();
        snakeSegments.Add(this.transform); 
    }

    private void Update()
    {
        HandleInput(); 
        HandleMovement();
    }

    private void HandleInput()
    {
        
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector2Int.down)
        {
            direction = Vector2Int.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && direction != Vector2Int.up)
        {
            direction = Vector2Int.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) && direction != Vector2Int.right)
        {
            direction = Vector2Int.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && direction != Vector2Int.left)
        {
            direction = Vector2Int.right;
        }
    }

    private void HandleMovement()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveTimerMax)
        {
            moveTimer -= moveTimerMax;

           
            Vector2Int previousPosition = gridPosition;
            gridPosition += direction;

           
            for (int i = snakeSegments.Count - 1; i > 0; i--)
            {
                snakeSegments[i].position = snakeSegments[i - 1].position;
            }

            // Atualiza a posição da cabeça da cobra
            transform.position = new Vector3(gridPosition.x, gridPosition.y, 0);
        }
    }

    public void Grow()
    {
      
        Transform newSegment = Instantiate(segmentPrefab);
        newSegment.position = snakeSegments[snakeSegments.Count - 1].position;
        snakeSegments.Add(newSegment);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            GameManager.Instance.ChangeDirection(Vector2Int.up);
        else if (Input.GetKeyDown(KeyCode.S))
            GameManager.Instance.ChangeDirection(Vector2Int.down);
        else if (Input.GetKeyDown(KeyCode.A))
            GameManager.Instance.ChangeDirection(Vector2Int.left);
        else if (Input.GetKeyDown(KeyCode.D))
            GameManager.Instance.ChangeDirection(Vector2Int.right);

        // Move a cobra a cada frame (você pode ajustar o intervalo)
        GameManager.Instance.MoveSnake();
    }
}

