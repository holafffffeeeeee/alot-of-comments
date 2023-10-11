using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI volumeValueText;
    public TextMeshProUGUI playModeButtonText;
    public TextMeshProUGUI menuObject;

    public System.Action onStartGame;

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

    public void OnQuitButtonClicked()
    {
        Debug.Log("quit");
        Application.Quit();
    }


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