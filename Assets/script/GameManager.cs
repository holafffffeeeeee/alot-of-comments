using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public int scorePlayer1, scorePlayer2;
    public ScoreScript scoreTextleft, scoreTextright;
    static PlayMode playMode;

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
        UpdateScores();
    }
    private void UpdateScores()
    {
        scoreTextleft.SetScore(scorePlayer1);
        scoreTextright.SetScore(scorePlayer2);
    }
 /*  public void SwitchPlayerMode(
      switch (PlayMode)
       case playMode.PlayerVsPlayer:
         playMode.PlayervsAI
 */
}
