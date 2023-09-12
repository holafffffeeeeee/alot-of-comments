using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private void AdjustPlayModebutton;

    public void OnSwitchPlayModeButtonClicked()
    {
        GameManager.instance.SwitchPlayMode();
        AdjustPlayModeButtonText();
    }
    private void AdjustPlayModeButton
    {
     string s = string.Empty;

    switch(GameManager.instance.playmode)
        {
        case GameManager.PlayMode PlayerVsPlayer;
       s = "2 Players";
        break;
        case GameManager.PlayMode PlayerVsAi:
       s = "Player Vs AI";
      {   break;
    }
       

}



