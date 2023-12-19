
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class BallScript : MonoBehaviour
{
    public GameManager gameManager;  // refrence till gamemanager
    public Rigidbody2D rb2d; // rigid body 2D
    public float maxInitialAngle = 0.67f; // vilken angle den ska sjuta sig 
    public float moveSpeed = 10f; //move speed = hur snapt bollen g�r
    public float maxStartY = 4f;// hur h�gt den ska skuta ifr�n
    private float startX = 0f; //  den b�rja ifron
    private float speedMultiplier = 1.1f;// den g�r smabbare n�r den tr�ffa borden

    // b�rja med att f� en knuff ock n�r g�r m�l so resettas den
    public void Start()
    {
        InitialPush();
        GameManager.instance.onReset += ResetBall;
        GameManager.instance.gameUI.onStartGame += ResetBall;

    }
    /*public void Start()
    {
        Debug.Log("Are you here?");
        
        InitialPush();
    }*/
    private void InitialPush()
    {
        Vector2 dir = Vector2.left;

        if (Random.value < 0.5f)
            dir = Vector2.right;

        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.velocity = dir * moveSpeed;

    }
    private void ResetBall()
    {
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone ScoreZone2 = collision.GetComponent<ScoreZone>();
        if (ScoreZone2)
        {
            GameManager.instance.OnScoreZoneReached(ScoreZone2.id);
            ResetBall();
            InitialPush();
        }
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
       PowerupScript powerup = collision.GetComponent<PowerupScript>();
        if ()
    }*/
   // n�r den tr�ffa bordet s� g� den snabare ock snabare
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BordScript bord = collision.collider.GetComponent<BordScript>();
        if (bord)
        {
            rb2d.velocity *= speedMultiplier;

            //AdjustAngle(paddle, collision);

        }
    }
}
