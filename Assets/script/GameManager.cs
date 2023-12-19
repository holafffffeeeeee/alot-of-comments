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
    public int scorePlayer1, scorePlayer2; //för att setta den till 0 typ
    public ScoreScript scoreTextleft, scoreTextright; //den ska kunna ändra på score texten genom scripts
    public PlayMode playMode; // ändra på play mode i gamemanagern 
    public GameUI gameUI; // refrence till game ui 
    public System.Action onReset; // för att resetta allt 
    public BallScript ball; // refrence tilt bollscript
    public BackGroundOnOff backgroundOnOff; // för at åndra knappen i background manager
    public GameObject backGroundImage; // refrence till bilden 
    public float id;// id I guess 
    
    // detta gör att allt resetas när spelet slutar at gå förutom score text 
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

 // destroy allt inan spelet börja 1 gång  

    private void OnDestroy()
    {
        gameUI.onStartGame -= OnStartGame;
    }
    // för att smla massa refrencer typ
    public enum PlayMode
    {
        PlayerVsPlayer,
        PlayerVsAI
    }
    // för att smla massa refrencer typ
    public enum BackGroundOnOff
    {
        BackGroundOn,
        BackGroundOff
    }
    //detta gör att när en gör mål den updatera poängen  
    public void OnScoreZoneReached(int id)
    {
        onReset?.Invoke();


        if (id == 1)
            scorePlayer1++;

        if (id == 2)
            scorePlayer2++;
        UpdateScores(scorePlayer1, scorePlayer2);
    }
    // reset påengen till 0
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
   // kolla om player 2 är AI
    public bool IsPlayer2Ai()
    {
        return playMode == PlayMode.PlayerVsAI;
    }
    //för att ändra bacground ish
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
