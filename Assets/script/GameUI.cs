using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI volumeValueText;  // refrence till volume text
    public TextMeshProUGUI playModeButtonText; // refrence till swich playmode button 
    public TextMeshProUGUI menuObject; // refrence till nånting 

    public System.Action onStartGame; // när spelet börja gör allt detta I think

    private void Start()
    {
        AdjustPlayModeButtonText();
    }

    public void OnStartGameButtonClicked()
    {
        onStartGame?.Invoke();
    }

    public void OnSwitchPlayModeButtonClicked()
        {
        GameManager.instance.SwitchPlayMode();
        AdjustPlayModeButtonText();
        }
    //exit button
    public void OnQuitButtonClicked()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    // byta mellan player ve player ock player vs ai text
    private void AdjustPlayModeButtonText()
    {
            switch (GameManager.instance.playMode) 
            { 
            case GameManager.PlayMode.PlayerVsPlayer:
                playModeButtonText.text = "2 Players";
            break;
            
            case GameManager.PlayMode.PlayerVsAI:
                playModeButtonText.text = "Player vs AI";
            break;
            }
         
    }
    public void OnVolumeChanged(float value)
    {
        volumeValueText.text = $"{Mathf.RoundToInt(value * 100)} %";
    }
}