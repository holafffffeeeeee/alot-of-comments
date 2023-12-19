using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using UnityEngine;
using static GameManager;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameManager gameManager;
    public int scorePlayer1, scorePlayer2; //f�r att setta den till 0 typ
    public ScoreScript scoreTextleft, scoreTextright; //den ska kunna �ndra p� score texten genom scripts
    public PlayMode playMode; // �ndra p� play mode i gamemanagern 
    public GameUI gameUI; // refrence till game ui 
    public System.Action onReset; // f�r att resetta allt 
    public BallScript ball; // refrence tilt bollscript
    public BackGroundOnOff backgroundOnOff; // f�r at �ndra knappen i background manager
    public GameObject backGroundImage; // refrence till bilden 
    public float id;// id I guess 
    
    // detta g�r att allt resetas n�r spelet slutar at g� f�rutom score text 
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(scoreTextleft);
            DontDestroyOnLoad(scoreTextright);
           
           
            instance = this;
            gameUI.onStartGame += OnStartGame;
        }
    }

 // destroy allt inan spelet b�rja 1 g�ng  

    private void OnDestroy()
    {
        gameUI.onStartGame -= OnStartGame;
    }
    // f�r att smla massa refrencer typ
    public enum PlayMode
    {
        PlayerVsPlayer,
        PlayerVsAI
    }
    // f�r att smla massa refrencer typ
    public enum BackGroundOnOff
    {
        BackGroundOn,
        BackGroundOff
    }
    //detta g�r att n�r en g�r m�l den updatera po�ngen  
    public void OnScoreZoneReached(int id)
    {
        onReset?.Invoke();


        if (id == 1)
            scorePlayer1++;

        if (id == 2)
            scorePlayer2++;
        UpdateScores(scorePlayer1, scorePlayer2);
    }
    // reset p�engen till 0
    public void OnStartGame()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        UpdateScores(scorePlayer1, scorePlayer2);

    }
    //updatera sores 
    private void UpdateScores(int player1, int player2)
    {
        scoreTextleft.SetScore(scorePlayer1);
        scoreTextright.SetScore(scorePlayer2);
    }
    //byta play mode som funka halft
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
   /* public PlayMode Confirmplaymode(float id)
    {
        if (id == 3 );
        PlayMode playerVsAI = PlayMode.PlayerVsAI;
    }*/
   // kolla om player 2 �r AI
    public bool IsPlayer2Ai()
    {
        return playMode == PlayMode.PlayerVsAI;
    }
    //f�r att �ndra bacground ish
    public void BackgroundOnOff()
    {
        Debug.Log("Switch");
        switch (backgroundOnOff)
        {
            case BackGroundOnOff.BackGroundOn:
                backgroundOnOff = BackGroundOnOff.BackGroundOff;
                break;
            case BackGroundOnOff.BackGroundOff:
                backgroundOnOff = BackGroundOnOff.BackGroundOn;
                break;
        }

    }

}
