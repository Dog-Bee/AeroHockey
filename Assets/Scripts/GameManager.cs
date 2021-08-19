using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    [SerializeField] private bool ballCaught;
    [SerializeField] private bool inGame;

    [Header("Player")]
    [SerializeField] private Transform launchIndicator;

    [Header("Enemy")]
    [SerializeField] private float enemyMoveSpeed;    

    [Header("Destructable")]
    [SerializeField] private int destructionCount;
    [SerializeField] private Transform destructionObstacle1;
    [SerializeField] private Transform destructionObstacle2;
    [SerializeField] private Transform destructionObstacle3;    

    [Header("Ball")]
    [SerializeField] private Transform ballPrefab;    
    [SerializeField] private Rigidbody ballRigBody;    
    [SerializeField] private Vector3 ballStartingPos;    
    [SerializeField] private float ballSpeed;

    [Header("Arena")]
    [SerializeField] private float sideEdgeDistance;    
    [SerializeField] private float topBotEdgeDistance;
    [SerializeField] private float topBotCenterDistance;

    [Header("Level Management")]
    [SerializeField] private int difficultyLevel;

    [Header("Menu")]
    [SerializeField] private Transform startButton;
    [SerializeField] private Transform pauseButton;
    [SerializeField] private Transform quitButton;
    [SerializeField] private Transform resumeButton;
    [SerializeField] private Text scoreLevel;



    void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);
    }

    //Properties
    public bool BallCaught { get { return inGame; } set { inGame = value; } }
    public bool InGame { get { return inGame; } set { inGame = value; } }

    //LaunchIndicator
    public Transform LaunchIndicator => launchIndicator;


    //Enemy
    public float EnemyMoveSpeed { get { return enemyMoveSpeed; } set { enemyMoveSpeed = value; } }
    //Destructions Obbstacles
    public int DestructionCount { get { return destructionCount; } set { destructionCount = value; } }
    public Transform DestructionObstacle1 => destructionObstacle1;
    public Transform DestructionObstacle2 => destructionObstacle2;
    public Transform DestructionObstacle3 => destructionObstacle3;


    //All Ball properties
    public Transform BallPrefab => ballPrefab;
    public Rigidbody BallRigBody => ballRigBody;
    public Vector3 BallStartingPos => ballStartingPos;
    public float BallSpeed { get { return ballSpeed; } set { ballSpeed = value; }}



    //Constraint for Player
    public float SideEdgeDistance => sideEdgeDistance;
    public float TopBotEdgeDistance => topBotEdgeDistance;
    public float TopBotCenterDistance => topBotCenterDistance;


    //Difficulty Level  that upgrade enemy move speed for each level
    public int DifficultyLevel { get { return difficultyLevel; } set { difficultyLevel = value; } }


    //UI
    public Transform StartButton => startButton;
    public Transform PauseButton => pauseButton;
    public Transform QuitButton => quitButton;
    public Transform ResumeButton => resumeButton;
    public Text ScoreLevel => scoreLevel;
    
}
