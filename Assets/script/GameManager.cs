using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int scorePlayer1, scorePlayer2;
    public ScoreScript scoreTextleft, scoreTextright;
    public PlayMode playMode;
    public GameUI gameUI;

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
        gameUI.onstartgame -= OnStartGame;
    }
    public enum PlayMode
    {
        PlayerVsPlayer,
        PlayerVsAI
    }

    public void OnScoreZoneReached(int id)
    {
        if (id == 1)
            scorePlayer1++;

        if (id == 2)
            scorePlayer2++;
       gameUI.UpdateScores(scorePlayer1, scorePlayer2);
    }
    private void OnStartGame()
    {
        scorePlayer1;
        scorePlayer2;
        gameUI.UpdateScores(scorePlayer1, scorePlayer2);

    }
    private void UpdateScores()
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
