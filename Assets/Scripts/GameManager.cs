using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int playerScore;
    private int botScore;
    private string matchScore = "0 - 0";
    private bool ballHeadingTowardBot = false;
    private float ballHeadingPoint;


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
        Debug.Log(x);
    }
    public string MatchScore()
    {
        return matchScore;
    }
}
