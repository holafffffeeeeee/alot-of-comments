using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI playModeButtonText;
    
        
        
        public void OnSwitchPlayModeButtonClicked()
        {
        GameManager.instance.SwitchPlayMode();
        AdjustPlayModeButtonText();
        }

    private void AdjustPlayModeButtonText()
    {

            switch (GameManager.instance.playmode) 
            { 
            case GameManager.PlayMode PlayerVsPlayer:
                playModeButtonText.text = "2 Players";
            break;
            case GameManager.PlayMode PlayerVsAi:
                playModeButtonText.text = "Player Vs AI";
            break;
            }
         
    }
}