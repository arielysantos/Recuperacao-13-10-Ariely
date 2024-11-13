using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour

{
    public static Transform bodyPrefab;
    public float speed = 10.0f;
    public float cellSize = 0.3f;

    private List<Transform> body = new List<Transform>();
    private Vector2 direction;
    private float changeCellTime = 0;
    private bool gameOver = false;

    private Comida comidaScript;

    private void Start()
    {
        
        direction = Vector2.up;
        SpawnInitialFood();
    }

    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R)) Restart();
            return;
        }

        ChangeDirection();
        Move();
        CheckCollisions();
    }

    private void ChangeDirection()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (input.y == -1) direction = Vector2.down;
        else if (input.y == 1) direction = Vector2.up;
        else if (input.x == -1) direction = Vector2.left;
        else if (input.x == 1) direction = Vector2.right;
    }

    private void Move()
    {
        if (Time.time > changeCellTime)
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].position = body[i - 1].position;
            }
            if (body.Count > 0) body[0].position = transform.position;
            transform.position += (Vector3)direction * cellSize;
            changeCellTime = Time.time + 1 / speed;
        }
    }

    public void GrowBody()
    {
        Vector2 position = body.Count > 0 ? body[body.Count - 1].position : (Vector2)transform.position;
        body.Add(Instantiate(bodyPrefab, position, Quaternion.identity).transform);
        GameManager.Instance.UpdateScore(1);
    }

    private void CheckCollisions()
    {
        if (CheckBodyCollision() || CheckWallCollision())
        {
            GameOver();
        }
    }

    private bool CheckBodyCollision()
    {
        for (int i = 0; i < body.Count; i++)
        {
            if (transform.position == body[i].position) return true;
        }
        return false;
    }

    private bool CheckWallCollision()
    {
        // Adicione a lógica de colisão com as paredes aqui
        return false;
    }

    private void GameOver()
    {
        gameOver = true;
        GameManager.Instance.ShowGameOver();
    }

    private void Restart()
    {
        gameOver = false;
        GameManager.Instance.HideGameOver();
        ResetSnake();
        SpawnInitialFood();
    }

    private void ResetSnake()
    {
        foreach (var segment in body)
        {
            Destroy(segment.gameObject);
        }
        body.Clear();
        GameManager.Instance.ResetScore();
        transform.position = Vector3.zero;
    }

    private void SpawnInitialFood()
    {

        if (comidaScript != null)
        {
            for (int i = 0; i < 10; i++)
            {
                comidaScript.SpawnFood();

            }
        }
    }
}

internal class Comida
{
    internal void SpawnFood()
    {
        throw new NotImplementedException();
    }
}