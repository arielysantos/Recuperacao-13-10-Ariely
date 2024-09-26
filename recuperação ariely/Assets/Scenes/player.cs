using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private float moveTimer;
    public float moveInterval = 0.2f;

    private void Update()
    {
        HandleInput();
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveInterval)
        {
            moveTimer = 0;
            GameManager.Instance.MoveSnake();
        }
    }

    private void HandleInput()
    {
        throw new NotImplementedException();
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

