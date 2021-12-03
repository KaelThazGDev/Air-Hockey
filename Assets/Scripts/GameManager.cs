using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int playerScore;
    private int botScore;
    private string matchScore = "0 - 0";
    private bool ballHeadingTowardBot = false;
    private float ballHeadingPoint;
    [SerializeField] private Text WhoWin;
    [SerializeField] private GameObject EndGameUI;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Bot;
    [SerializeField] private GameObject Ball;
    [SerializeField] private GameObject MScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
            
    DontDestroyOnLoad(instance);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayerScore(bool isScore)
    {
        if (isScore)
        {
            playerScore++;
        }
        else
        {
            botScore++;
        }
        matchScore = playerScore + " - " + botScore;
        MScore.GetComponent<Text>().text = matchScore;
        if (playerScore == 5)
        {
            WhoWin.text = "You Win !!!";
            MScore.GetComponent<Text>().text = null;
            EndGamePopUp();
        }
        if (botScore ==5)
        {
            WhoWin.text = "You Lose :(";
            MScore.GetComponent<Text>().text = null;
            EndGamePopUp();
        }
    }
    public bool IfBallHeadingTowardBot()
    {
        return ballHeadingTowardBot;
    }
    public void BallHeadingTowardBot(bool bot)
    {
        ballHeadingTowardBot = bot;
    }
    public float BallHeadingTowardPoint()
    {
        return ballHeadingPoint;
    }
    public void SetBallHeadingPoint(float x)
    {
        ballHeadingPoint = x;
    }
    public string MatchScore()
    {
        return matchScore;
    }

    public void EndGamePopUp()
    {
        EndGameUI.SetActive(true);
        MScore.SetActive(false);
    }

    public void NewGame()
    {
        matchScore = "0 - 0";
        playerScore = 0;
        botScore = 0;
        Bot.transform.position = new Vector3(0, 8.3f, 0);
        Player.transform.position = new Vector3(0, -8.3f, 0);
        Ball.transform.position = new Vector3(0, -6.3f, 0);
        Ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        EndGameUI.SetActive(false);
        MScore.SetActive(true);
    }
    public void ExitGame()
    {
        EditorApplication.isPlaying = false;
    }
}
