using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    // Singleton para garantir que exista apenas uma instância do GameManager no jogo
    public static GameManager Instance { get; private set; }

    // Dimensões do grid do jogo
    public int width = 20;
    public int height = 20;

    // Prefabs para os segmentos da cobra e para a comida
    public GameObject snakeSegmentPrefab;
    public GameObject foodPrefab;

    // Lista que armazena os segmentos da cobra
    private List<Transform> snake = new List<Transform>();

    // Direção atual da cobra
    private Vector2 direction;

    // Referência ao objeto da comida
    private Transform food;

    // Método chamado quando o script é inicializado
    private void Awake()
    {
        // Define a instância do singleton
        if (Instance == null)
        {
            Instance = this;
            InitializeGame();
        }
        else
        {
            // Destroi o objeto duplicado, mantendo apenas uma instância
            Destroy(gameObject);
        }
    }

    // Método para inicializar o jogo
    private void InitializeGame()
    {
        throw new NotImplementedException();
    }

    // Método para criar a cobra no início do jogo
    private void SpawnSnake()
    {
        // Adiciona 3 segmentos iniciais para a cobra
        for (int i = 0; i < 3; i++)
        {
            AddSnakeSegment(new Vector2(i, 0));
        }
    }

    // Método para adicionar um segmento à cobra na posição especificada
    private void AddSnakeSegment(Vector2 position)
    {
        throw new NotImplementedException();
    }

    // Método para spawnar (criar) a comida em uma posição aleatória do grid
    private void SpawnFood()
    {
        // Se já existe uma comida, destrói a antiga antes de criar uma nova
        if (food != null) Destroy(food.gameObject);

        Vector2 position;
        do
        {
            // Gera uma posição aleatória dentro dos limites do grid
            position = new Vector2(UnityEngine.Random.Range(0, width), UnityEngine.Random.Range(0, height));
        } while (IsPositionOccupied(position)); // Verifica se a posição já está ocupada

        // Instancia a comida na posição aleatória e armazena sua referência
        food = Instantiate(foodPrefab, position, Quaternion.identity).transform;
    }

    // Método para verificar se uma posição está ocupada pela cobra
    private bool IsPositionOccupied(Vector2 position)
    {
        throw new NotImplementedException();
    }

    // Método para mudar a direção da cobra
    public void ChangeDirection(Vector2 newDirection)
    {
        // Evita que a cobra faça um movimento reverso
        if (newDirection != -direction)
            direction = newDirection;
    }

    // Método para mover a cobra na direção atual
    public void MoveSnake()
    {
        // Calcula a nova posição do segmento da cabeça com base na direção
        Vector2 newPosition = (Vector2)snake[0].position + direction;

        // Verifica se houve colisão com as bordas ou com o próprio corpo
        if (CheckCollision(newPosition))
        {
            Debug.Log("Game Over!");
            return; // Termina o jogo em caso de colisão
        }

        // Cria um novo segmento para a cobra na nova posição
        Transform newSegment = Instantiate(snakeSegmentPrefab, newPosition, Quaternion.identity).transform;
        snake.Insert(0, newSegment); // Adiciona o novo segmento à cabeça da cobra

        // Se a cobra

    }

<<<<<<< Updated upstream
    private bool CheckCollision(Vector2 position)
    {
        if (position.x < 0 || position.x >= width || position.y < 0 || position.y >= height)
            return true; // Colisão com as bordas
        foreach (var segment in snake)
        {
            if (segment.position == (Vector3)position) return true; // Colisão com o corpo
        }
        return false;
=======
    private bool CheckCollision(Vector2 newPosition)
    {
        throw new NotImplementedException();
>>>>>>> Stashed changes
    }
}

