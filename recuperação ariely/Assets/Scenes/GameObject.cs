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
}
