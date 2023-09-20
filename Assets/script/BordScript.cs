using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BordScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float id;
    public float moveSpeed = 1.0f;

    public Transform ballPos;

    private void Update()
    {
        if(id == 3 && GameManager.instance.IsPlayer2Ai())
        {
            MoveAI();
        }
        else
        {
            float movement = ProcessInput();
            Move(movement);
        }
        
    }
    private void MoveAI()
    {
        Vector2 ballpos = GameManager.instance.transform.position;
        transform.position = new Vector2(startPosition.x, ballPos.y);
    }

    private float ProcessInput()
    {
        float movement = 0f;
        switch (id)
        {
            case 1:
                movement = Input.GetAxis("movePlayer1");
                break;

            case 2:
                movement = Input.GetAxis("movePlayer2");
                break;

            case 3:

                //Debug.Log("normed   "+ballPos.position.normalized.y);

                movement = ballPos.position.normalized.y;

                break;

                

        }
        return movement;
    }
  /*  public void If() 
    {
        if (dir <= moveSpeed) ;
    }
       */
   private void Move(float movement)
    {
        Vector2 valo = rb2d.velocity;
        valo.y = moveSpeed * movement;
        rb2d.velocity = valo;
    }
}
