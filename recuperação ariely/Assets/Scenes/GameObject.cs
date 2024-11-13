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
            InitializeGame1();
        }
        else
        {

        }
    }

    private void InitializeGame1()
    {
        currentDirection = Vector2Int.right;
        CreateSnake1();
        SpawnFood1();
    }

    private static void SpawnFood1()
    {
        throw new NotImplementedException();
    }

    private void CreateSnake1()
    {
        Vector2Int startPosition = new Vector2Int(boardWidth / 2, boardHeight / 2);

        for (int i = 0; i < 3; i++)
        {

            Vector2Int position = startPosition - new Vector2Int(i, 0);
            AddSnakeSegment1(position);
        }
    }

    private static void AddSnakeSegment1(Vector2Int position)
    {
        throw new NotImplementedException();
    }

    private void MoveSnake1()
    {

        Vector2Int newPosition = Vector2Int.RoundToInt(snakeSegments[0].position) + currentDirection;

        if (CheckCollision1(newPosition))
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

            // Gera comida em uma posição aleatória
        }

        // Adiciona um novo segmento na nova posição da cabeça
        AddSnakeSegment(newPosition);
    }

    private void InitializeGame()
    {
        currentDirection = Vector2Int.right; // Define a direção inicial para a direita
        InitializeSnake(); // Cria a cobra com os segmentos iniciais
        SpawnFood(); // Coloca a comida no tabuleiro
    }

    private static void SpawnFood()
    {
        throw new NotImplementedException(); // Este método ainda precisa ser implementado
    }

    private static void CreateSnake() => throw new NotImplementedException(); // Ainda não implementado

    private void InitializeSnake()
    {
        // Define a posição inicial da cabeça da cobra no centro do tabuleiro
        Vector2Int startPosition = new Vector2Int(boardWidth / 2, boardHeight / 2);

        // Adiciona 3 segmentos iniciais da cobra na direção esquerda
        for (int i = 0; i < 3; i++)
        {
            // Calcula a posição de cada segmento inicial
            Vector2Int position = startPosition - new Vector2Int(i, 0);
            AddSnakeSegment(position); // Adiciona um segmento na posição
        }
    }

    private static void AddSnakeSegment(Vector2Int position)
    {
        throw new NotImplementedException(); // Este método ainda precisa ser implementado
    }

    private void MoveSnake()
    {
        // Calcula a nova posição da cabeça com base na direção atual
        Vector2Int newPosition = Vector2Int.RoundToInt(snakeSegments[0].position) + currentDirection;

        // Verifica se a nova posição resultará em uma colisão
        if (CheckCollision1(newPosition))
        {
            Debug.Log("Game Over!"); // Exibe a mensagem de Game Over no console
            return; // Finaliza o método, não movendo a cobra
        }

        // Verifica se a nova posição coincide com a posição da comida
        if (newPosition == foodPosition)
        {
            SpawnFood(); // Se comeu a comida, cria uma nova comida
        }
        else
        {
            // Se não comeu a comida, remove o último segmento (a cauda)

            Destroy(snakeSegments[snakeSegments.Count - 1].gameObject);
            snakeSegments.RemoveAt(snakeSegments.Count - 1);
        }



        AddSnakeSegment(newPosition);
    }

    private static bool CheckCollision1(Vector2Int newPosition)
    {
        throw new NotImplementedException(); // Este método ainda precisa ser implementado
    }

    private static bool CheckCollision(Vector2Int newPosition)
    {
        throw new NotImplementedException();
    }

    private void ChangeDirection1(Vector2Int newDirection)
    {
        // Impede que a cobra se mova para a direção oposta diretamente
        if (newDirection != -currentDirection)
        {
            currentDirection = newDirection;
        }
    }

    private void ChangeDirection(Vector2Int newDirection)
    {
        // Evita que a cobra se mova na direção oposta à sua direção atual
        if (newDirection != -currentDirection)
        {
            currentDirection = newDirection; // Atualiza a direção da cobra
        }
    }
}

    


