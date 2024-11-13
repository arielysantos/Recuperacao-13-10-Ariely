using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameObject : MonoBehaviour
{
<<<<<<< Updated upstream
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
            InitializeGame();
        }
        else
        {
=======
    // Singleton para garantir que haja apenas uma instância de GameManager
    public static GameManager Instance { get; private set; }

    // Prefabs para o segmento da cobra e para a comida
    public GameObject snakeSegmentPrefab;
    public GameObject foodPrefab;

    // Dimensões do tabuleiro do jogo
    public int boardWidth = 20;
    public int boardHeight = 20;

    // Lista para armazenar os segmentos da cobra
    private List<Transform> snakeSegments = new List<Transform>();

    // Direção atual da cobra
    private Vector2Int currentDirection;

    // Referência ao objeto de comida instanciado
    private Transform foodInstance;

    // Posição da comida no grid
    private Vector2Int foodPosition;

    // Método Awake é chamado quando o script é inicializado
    private void Awake()
    {
        // Verifica se a instância já foi criada
        if (Instance == null)
        {
            Instance = this; // Define a instância
            InitializeGame(); // Inicia o jogo
        }
        else
        {
            // Destroi este objeto se uma instância já existe
>>>>>>> Stashed changes
            Destroy(gameObject);
        }
    }

<<<<<<< Updated upstream

    private void InitializeGame()
    {
        currentDirection = Vector2Int.right;
        CreateSnake();
        SpawnFood();
    }

    private void SpawnFood()
    {
        throw new NotImplementedException();
    }

    private void CreateSnake()
    {
        throw new NotImplementedException();
    }

    private void CreateSnake()
    {
        Vector2Int startPosition = new Vector2Int(boardWidth / 2, boardHeight / 2);

        for (int i = 0; i < 3; i++)
        {

            Vector2Int position = startPosition - new Vector2Int(i, 0);
            AddSnakeSegment(position);
        }
    }

    private void AddSnakeSegment(Vector2Int position)
    {
        throw new NotImplementedException();
    }

    public void MoveSnake()
    {

        Vector2Int newPosition = Vector2Int.RoundToInt(snakeSegments[0].position) + currentDirection;

        if (CheckCollision(newPosition))
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

=======
    // Método para inicializar o jogo, definindo direção e criando a cobra e comida
    private void InitializeGame()
    {
        currentDirection = Vector2Int.right; // Define a direção inicial para a direita
        InitializeSnake(); // Cria a cobra com os segmentos iniciais
        SpawnFood(); // Coloca a comida no tabuleiro
    }

    // Método para spawnar (criar) a comida em uma posição aleatória
    private void SpawnFood()
    {
        throw new NotImplementedException(); // Este método ainda precisa ser implementado
    }

    // Método para criar a cobra (aqui apenas uma implementação básica)
    private void CreateSnake() => throw new NotImplementedException(); // Ainda não implementado

    // Método para inicializar a cobra com 3 segmentos na posição inicial
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

    // Método para adicionar um segmento da cobra na posição especificada
    private void AddSnakeSegment(Vector2Int position)
    {
        throw new NotImplementedException(); // Este método ainda precisa ser implementado
    }

    // Método para mover a cobra a cada atualização do jogo
    public void MoveSnake()
    {
        // Calcula a nova posição da cabeça com base na direção atual
        Vector2Int newPosition = Vector2Int.RoundToInt(snakeSegments[0].position) + currentDirection;

        // Verifica se a nova posição resultará em uma colisão
        if (CheckCollision(newPosition))
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
>>>>>>> Stashed changes
            Destroy(snakeSegments[snakeSegments.Count - 1].gameObject);
            snakeSegments.RemoveAt(snakeSegments.Count - 1);
        }

<<<<<<< Updated upstream

        AddSnakeSegment(newPosition);
    }

    private bool CheckCollision(Vector2Int newPosition)
    {
        throw new NotImplementedException();
    }

    public void ChangeDirection(Vector2Int newDirection)
    {
        // Impede que a cobra se mova para a direção oposta diretamente
        if (newDirection != -currentDirection)
        {
            currentDirection = newDirection;
        }
    }

    // Gera comida em uma posição aleatória
}
=======
        // Adiciona um novo segmento na nova posição da cabeça
        AddSnakeSegment(newPosition);
    }

    // Método para verificar colisões com as bordas ou o próprio corpo
    private bool CheckCollision(Vector2Int newPosition)
    {
        throw new NotImplementedException(); // Este método ainda precisa ser implementado
    }

    // Método para mudar a direção da cobra com base na entrada do jogador
    public void ChangeDirection(Vector2Int newDirection)
    {
        // Evita que a cobra se mova na direção oposta à sua direção atual
        if (newDirection != -currentDirection)
        {
            currentDirection = newDirection; // Atualiza a direção da cobra
        }
    }
}

    

>>>>>>> Stashed changes
