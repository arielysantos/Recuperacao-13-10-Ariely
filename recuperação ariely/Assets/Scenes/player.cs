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
}
