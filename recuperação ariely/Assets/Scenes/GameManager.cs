using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    // Singleton para garantir que exista apenas uma inst�ncia do GameManager no jogo
    public static GameManager Instance { get; private set; }

    // Dimens�es do grid do jogo
    public int width = 20;
    public int height = 20;

    // Prefabs para os segmentos da cobra e para a comida
    public GameObject snakeSegmentPrefab;
    public GameObject foodPrefab;

    // Lista que armazena os segmentos da cobra
    private List<Transform> snake = new List<Transform>();

    // Dire��o atual da cobra
    private Vector2 direction;

    // Refer�ncia ao objeto da comida
    private Transform food;

    // M�todo chamado quando o script � inicializado
    private void Awake()
    {
        // Define a inst�ncia do singleton
        if (Instance == null)
        {
            Instance = this;
            InitializeGame();
        }
        else
        {
            // Destroi o objeto duplicado, mantendo apenas uma inst�ncia
            Destroy(gameObject);
        }
    }

    // M�todo para inicializar o jogo
    private void InitializeGame()
    {
        throw new NotImplementedException();
    }

    // M�todo para criar a cobra no in�cio do jogo
    private void SpawnSnake()
    {
        // Adiciona 3 segmentos iniciais para a cobra
        for (int i = 0; i < 3; i++)
        {
            AddSnakeSegment(new Vector2(i, 0));
        }
    }

    // M�todo para adicionar um segmento � cobra na posi��o especificada
    private void AddSnakeSegment(Vector2 position)
    {
        throw new NotImplementedException();
    }

    // M�todo para spawnar (criar) a comida em uma posi��o aleat�ria do grid
    private void SpawnFood()
    {
        // Se j� existe uma comida, destr�i a antiga antes de criar uma nova
        if (food != null) Destroy(food.gameObject);

        Vector2 position;
        do
        {
            // Gera uma posi��o aleat�ria dentro dos limites do grid
            position = new Vector2(UnityEngine.Random.Range(0, width), UnityEngine.Random.Range(0, height));
        } while (IsPositionOccupied(position)); // Verifica se a posi��o j� est� ocupada

        // Instancia a comida na posi��o aleat�ria e armazena sua refer�ncia
        food = Instantiate(foodPrefab, position, Quaternion.identity).transform;
    }

    // M�todo para verificar se uma posi��o est� ocupada pela cobra
    private bool IsPositionOccupied(Vector2 position)
    {
        throw new NotImplementedException();
    }

    // M�todo para mudar a dire��o da cobra
    public void ChangeDirection(Vector2 newDirection)
    {
        // Evita que a cobra fa�a um movimento reverso
        if (newDirection != -direction)
            direction = newDirection;
    }

    // M�todo para mover a cobra na dire��o atual
    public void MoveSnake()
    {
        // Calcula a nova posi��o do segmento da cabe�a com base na dire��o
        Vector2 newPosition = (Vector2)snake[0].position + direction;

        // Verifica se houve colis�o com as bordas ou com o pr�prio corpo
        if (CheckCollision(newPosition))
        {
            Debug.Log("Game Over!");
            return; // Termina o jogo em caso de colis�o
        }

        // Cria um novo segmento para a cobra na nova posi��o
        Transform newSegment = Instantiate(snakeSegmentPrefab, newPosition, Quaternion.identity).transform;
        snake.Insert(0, newSegment); // Adiciona o novo segmento � cabe�a da cobra

        // Se a cobra

    }

<<<<<<< Updated upstream
    private bool CheckCollision(Vector2 position)
    {
        if (position.x < 0 || position.x >= width || position.y < 0 || position.y >= height)
            return true; // Colis�o com as bordas
        foreach (var segment in snake)
        {
            if (segment.position == (Vector3)position) return true; // Colis�o com o corpo
        }
        return false;
=======
    private bool CheckCollision(Vector2 newPosition)
    {
        throw new NotImplementedException();
>>>>>>> Stashed changes
    }
}

