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
    // Singleton para garantir que haja apenas uma inst�ncia de GameManager
    public static GameManager Instance { get; private set; }

    // Prefabs para o segmento da cobra e para a comida
    public GameObject snakeSegmentPrefab;
    public GameObject foodPrefab;

    // Dimens�es do tabuleiro do jogo
    public int boardWidth = 20;
    public int boardHeight = 20;

    // Lista para armazenar os segmentos da cobra
    private List<Transform> snakeSegments = new List<Transform>();

    // Dire��o atual da cobra
    private Vector2Int currentDirection;

    // Refer�ncia ao objeto de comida instanciado
    private Transform foodInstance;

    // Posi��o da comida no grid
    private Vector2Int foodPosition;

    // M�todo Awake � chamado quando o script � inicializado
    private void Awake()
    {
        // Verifica se a inst�ncia j� foi criada
        if (Instance == null)
        {
            Instance = this; // Define a inst�ncia
            InitializeGame(); // Inicia o jogo
        }
        else
        {
            // Destroi este objeto se uma inst�ncia j� existe
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
    // M�todo para inicializar o jogo, definindo dire��o e criando a cobra e comida
    private void InitializeGame()
    {
        currentDirection = Vector2Int.right; // Define a dire��o inicial para a direita
        InitializeSnake(); // Cria a cobra com os segmentos iniciais
        SpawnFood(); // Coloca a comida no tabuleiro
    }

    // M�todo para spawnar (criar) a comida em uma posi��o aleat�ria
    private void SpawnFood()
    {
        throw new NotImplementedException(); // Este m�todo ainda precisa ser implementado
    }

    // M�todo para criar a cobra (aqui apenas uma implementa��o b�sica)
    private void CreateSnake() => throw new NotImplementedException(); // Ainda n�o implementado

    // M�todo para inicializar a cobra com 3 segmentos na posi��o inicial
    private void InitializeSnake()
    {
        // Define a posi��o inicial da cabe�a da cobra no centro do tabuleiro
        Vector2Int startPosition = new Vector2Int(boardWidth / 2, boardHeight / 2);

        // Adiciona 3 segmentos iniciais da cobra na dire��o esquerda
        for (int i = 0; i < 3; i++)
        {
            // Calcula a posi��o de cada segmento inicial
            Vector2Int position = startPosition - new Vector2Int(i, 0);
            AddSnakeSegment(position); // Adiciona um segmento na posi��o
        }
    }

    // M�todo para adicionar um segmento da cobra na posi��o especificada
    private void AddSnakeSegment(Vector2Int position)
    {
        throw new NotImplementedException(); // Este m�todo ainda precisa ser implementado
    }

    // M�todo para mover a cobra a cada atualiza��o do jogo
    public void MoveSnake()
    {
        // Calcula a nova posi��o da cabe�a com base na dire��o atual
        Vector2Int newPosition = Vector2Int.RoundToInt(snakeSegments[0].position) + currentDirection;

        // Verifica se a nova posi��o resultar� em uma colis�o
        if (CheckCollision(newPosition))
        {
            Debug.Log("Game Over!"); // Exibe a mensagem de Game Over no console
            return; // Finaliza o m�todo, n�o movendo a cobra
        }

        // Verifica se a nova posi��o coincide com a posi��o da comida
        if (newPosition == foodPosition)
        {
            SpawnFood(); // Se comeu a comida, cria uma nova comida
        }
        else
        {
            // Se n�o comeu a comida, remove o �ltimo segmento (a cauda)
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
        // Impede que a cobra se mova para a dire��o oposta diretamente
        if (newDirection != -currentDirection)
        {
            currentDirection = newDirection;
        }
    }

    // Gera comida em uma posi��o aleat�ria
}
=======
        // Adiciona um novo segmento na nova posi��o da cabe�a
        AddSnakeSegment(newPosition);
    }

    // M�todo para verificar colis�es com as bordas ou o pr�prio corpo
    private bool CheckCollision(Vector2Int newPosition)
    {
        throw new NotImplementedException(); // Este m�todo ainda precisa ser implementado
    }

    // M�todo para mudar a dire��o da cobra com base na entrada do jogador
    public void ChangeDirection(Vector2Int newDirection)
    {
        // Evita que a cobra se mova na dire��o oposta � sua dire��o atual
        if (newDirection != -currentDirection)
        {
            currentDirection = newDirection; // Atualiza a dire��o da cobra
        }
    }
}

    

>>>>>>> Stashed changes
