using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour

{
    // Posi��o da cabe�a da cobra no grid do jogo
    public Vector2Int gridPosition;

    // Intervalo de tempo entre os movimentos da cobra (quanto menor, mais r�pida a cobra se move)
    public float moveTimerMax = 0.3f;

    // Temporizador que conta o tempo desde o �ltimo movimento
    private float moveTimer;

    // Dire��o atual da cobra (para onde ela vai se mover)
    private Vector2Int direction;

    // Lista que armazena os segmentos da cobra
    private List<Transform> snakeSegments;

    // Prefab para instanciar novos segmentos da cobra
    public Transform segmentPrefab;

    // M�todo chamado no in�cio do jogo para inicializar a cobra
    private void Start()
    {
        // Define a posi��o inicial da cabe�a da cobra no centro do grid
        gridPosition = new Vector2Int(10, 10);

        // Inicia o temporizador com o valor m�ximo para garantir que a cobra se mova imediatamente
        moveTimer = moveTimerMax;

        // Define a dire��o inicial da cobra para a direita
        direction = Vector2Int.right;

        // Inicializa a lista de segmentos da cobra e adiciona a cabe�a como primeiro segmento
        snakeSegments = new List<Transform>();
        snakeSegments.Add(this.transform);
    }

    // M�todo chamado a cada frame para capturar entrada e atualizar o movimento
    private void Update()
    {
        HandleInput(); // Captura a entrada do jogador para mudar a dire��o
        HandleMovement(); // Atualiza a posi��o da cobra com base na dire��o
    }

    // M�todo para capturar a entrada do jogador e atualizar a dire��o da cobra
    private void HandleInput()
    {
        // Se o jogador pressiona W e a dire��o atual n�o � para baixo
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector2Int.down)
        {
            direction = Vector2Int.up; // Define a dire��o para cima
        }
        // Se o jogador pressiona S e a dire��o atual n�o � para cima
        else if (Input.GetKeyDown(KeyCode.S) && direction != Vector2Int.up)
        {
            direction = Vector2Int.down; // Define a dire��o para baixo
        }
        // Se o jogador pressiona A e a dire��o atual n�o � para a direita
        else if (Input.GetKeyDown(KeyCode.A) && direction != Vector2Int.right)
        {
            direction = Vector2Int.left; // Define a dire��o para a esquerda
        }
        // Se o jogador pressiona D e a dire��o atual n�o � para a esquerda
        else if (Input.GetKeyDown(KeyCode.D) && direction != Vector2Int.left)
        {
            direction = Vector2Int.right; // Define a dire��o para a direita
        }
    }

    // M�todo para atualizar o movimento da cobra no grid
    private void HandleMovement()
    {
        // Atualiza o temporizador com o tempo desde o �ltimo frame
        moveTimer += Time.deltaTime;

        // Se o temporizador atingiu o valor m�ximo, � hora de mover a cobra
        if (moveTimer >= moveTimerMax)
        {
            // Reseta o temporizador subtraindo o valor m�ximo
            moveTimer -= moveTimerMax;

            // Salva a posi��o atual da cabe�a para atualizar os segmentos
            Vector2Int previousPosition = gridPosition;

            // Atualiza a posi��o da cabe�a com base na dire��o
            gridPosition += direction;

            // Move cada segmento para a posi��o do segmento � frente, come�ando do �ltimo
            for (int i = snakeSegments.Count - 1; i > 0; i--)
            {
                snakeSegments[i].position = snakeSegments[i - 1].position;
            }

            // Atualiza a posi��o da cabe�a no grid para a nova posi��o
            transform.position = new Vector3(gridPosition.x, gridPosition.y, 0);
        }
    }

    // M�todo para fazer a cobra crescer ao comer comida
    public void Grow()
    {
        // Instancia um novo segmento da cobra e coloca na posi��o do �ltimo segmento atual
        Transform newSegment = Instantiate(segmentPrefab);
        newSegment.position = snakeSegments[snakeSegments.Count - 1].position;

        // Adiciona o novo segmento � lista de segmentos da cobra
        snakeSegments.Add(newSegment);
    }

    // M�todo adicional para sincronizar a dire��o com o GameManager
    private void Update()
    {
        // Checa a entrada do jogador e atualiza a dire��o da cobra atrav�s do GameManager
        if (Input.GetKeyDown(KeyCode.W))
            GameManager.Instance.ChangeDirection(Vector2Int.up);
        else if (Input.GetKeyDown(KeyCode.S))
            GameManager.Instance.ChangeDirection(Vector2Int.down);
        else if (Input.GetKeyDown(KeyCode.A))
            GameManager.Instance.ChangeDirection(Vector2Int.left);
        else if (Input.GetKeyDown(KeyCode.D))
            GameManager.Instance.ChangeDirection(Vector2Int.right);

        // Move a cobra usando o m�todo do GameManager a cada frame
        GameManager.Instance.MoveSnake();
    }
}


