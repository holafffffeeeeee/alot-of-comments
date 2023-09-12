/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorecap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone ScoreZone2 = collision.GetComponent<ScoreZone>();
        if (ScoreZone2)
        {
            gameManager.OnScoreZoneReached(ScoreZone2.id);
            ResetBall();
            InitialPush();
        }
        else if (id >= 30) { }
    }
}*/