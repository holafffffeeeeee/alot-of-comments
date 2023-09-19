using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   
    public GameManager gameManager;
    public int scorePlayer1, scorePlayer2;
    public ScoreScript scoreTextleft, scoreTextright;
    public PlayMode playMode;
    public GameUI gameUI;
    public System.Action onReset;
    public BallScript ball;

    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance= this;
            gameUI.onStartGame += OnStartGame;
        }
    }
    private void OnDestroy()
    {
        gameUI.onStartGame -= OnStartGame;
    }
    public enum PlayMode
    {
        PlayerVsPlayer,
        PlayerVsAI
    }

    public void OnScoreZoneReached(int id)
    {
            onReset?.Invoke();


        if (id == 1)
            scorePlayer1++;

        if (id == 2)
            scorePlayer2++;
       UpdateScores(scorePlayer1, scorePlayer2);
    }
    private void OnStartGame()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
       UpdateScores(scorePlayer1, scorePlayer2);

    }
    private void UpdateScores(int player1, int player2)
    {
        scoreTextleft.SetScore(scorePlayer1);
        scoreTextright.SetScore(scorePlayer2);
    }
   public void SwitchPlayMode()
   {
        Debug.Log("Switch");
        switch (playMode)
        {
            case PlayMode.PlayerVsPlayer:
                playMode = PlayMode.PlayerVsAI;
                break;
            case PlayMode.PlayerVsAI:
                playMode = PlayMode.PlayerVsPlayer;
                break;
        }
    }  
     

}   
