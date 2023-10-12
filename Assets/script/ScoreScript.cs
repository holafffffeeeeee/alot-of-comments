using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameManager gameManager;
    public void SetScore(int value)
    {
        text.text = value.ToString();
    }

    public void UpdateScores(int player1, int player2)
    {
        GameManager.instance.scoreTextleft.SetScore(GameManager.instance.scorePlayer1);
        GameManager.instance.scoreTextright.SetScore(GameManager.instance.scorePlayer2);
    }
}