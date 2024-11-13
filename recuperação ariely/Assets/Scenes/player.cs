using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour

{
    // Posição da cabeça da cobra no grid do jogo
    public Vector2Int gridPosition;

    // Intervalo de tempo entre os movimentos da cobra (quanto menor, mais rápida a cobra se move)
    public float moveTimerMax = 0.3f;

    // Temporizador que conta o tempo desde o último movimento
    private float moveTimer;

    // Direção atual da cobra (para onde ela vai se mover)
    private Vector2Int direction;

    // Lista que armazena os segmentos da cobra
    private List<Transform> snakeSegments;

    // Prefab para instanciar novos segmentos da cobra
    public Transform segmentPrefab;

    // Método chamado no início do jogo para inicializar a cobra
    private void Start()
    {
        // Define a posição inicial da cabeça da cobra no centro do grid
        gridPosition = new Vector2Int(10, 10);

        // Inicia o temporizador com o valor máximo para garantir que a cobra se mova imediatamente
        moveTimer = moveTimerMax;

        // Define a direção inicial da cobra para a direita
        direction = Vector2Int.right;

        // Inicializa a lista de segmentos da cobra e adiciona a cabeça como primeiro segmento
        snakeSegments = new List<Transform>();
        snakeSegments.Add(this.transform);
    }

    // Método chamado a cada frame para capturar entrada e atualizar o movimento
    private void Update()
    {
        HandleInput(); // Captura a entrada do jogador para mudar a direção
        HandleMovement(); // Atualiza a posição da cobra com base na direção
    }

    // Método para capturar a entrada do jogador e atualizar a direção da cobra
    private void HandleInput()
    {
        // Se o jogador pressiona W e a direção atual não é para baixo
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector2Int.down)
        {
            direction = Vector2Int.up; // Define a direção para cima
        }
        // Se o jogador pressiona S e a direção atual não é para cima
        else if (Input.GetKeyDown(KeyCode.S) && direction != Vector2Int.up)
        {
            direction = Vector2Int.down; // Define a direção para baixo
        }
        // Se o jogador pressiona A e a direção atual não é para a direita
        else if (Input.GetKeyDown(KeyCode.A) && direction != Vector2Int.right)
        {
            direction = Vector2Int.left; // Define a direção para a esquerda
        }
        // Se o jogador pressiona D e a direção atual não é para a esquerda
        else if (Input.GetKeyDown(KeyCode.D) && direction != Vector2Int.left)
        {
            direction = Vector2Int.right; // Define a direção para a direita
        }
    }

    // Método para atualizar o movimento da cobra no grid
    private void HandleMovement()
    {
        // Atualiza o temporizador com o tempo desde o último frame
        moveTimer += Time.deltaTime;

        // Se o temporizador atingiu o valor máximo, é hora de mover a cobra
        if (moveTimer >= moveTimerMax)
        {
            // Reseta o temporizador subtraindo o valor máximo
            moveTimer -= moveTimerMax;

            // Salva a posição atual da cabeça para atualizar os segmentos
            Vector2Int previousPosition = gridPosition;

            // Atualiza a posição da cabeça com base na direção
            gridPosition += direction;

            // Move cada segmento para a posição do segmento à frente, começando do último
            for (int i = snakeSegments.Count - 1; i > 0; i--)
            {
                snakeSegments[i].position = snakeSegments[i - 1].position;
            }

            // Atualiza a posição da cabeça no grid para a nova posição
            transform.position = new Vector3(gridPosition.x, gridPosition.y, 0);
        }
    }

    // Método para fazer a cobra crescer ao comer comida
    public void Grow()
    {
        // Instancia um novo segmento da cobra e coloca na posição do último segmento atual
        Transform newSegment = Instantiate(segmentPrefab);
        newSegment.position = snakeSegments[snakeSegments.Count - 1].position;

        // Adiciona o novo segmento à lista de segmentos da cobra
        snakeSegments.Add(newSegment);
    }

    // Método adicional para sincronizar a direção com o GameManager
    private void Update()
    {
        // Checa a entrada do jogador e atualiza a direção da cobra através do GameManager
        if (Input.GetKeyDown(KeyCode.W))
            GameManager.Instance.ChangeDirection(Vector2Int.up);
        else if (Input.GetKeyDown(KeyCode.S))
            GameManager.Instance.ChangeDirection(Vector2Int.down);
        else if (Input.GetKeyDown(KeyCode.A))
            GameManager.Instance.ChangeDirection(Vector2Int.left);
        else if (Input.GetKeyDown(KeyCode.D))
            GameManager.Instance.ChangeDirection(Vector2Int.right);

        // Move a cobra usando o método do GameManager a cada frame
        GameManager.Instance.MoveSnake();
    }
}


