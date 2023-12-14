using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BordScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float id;
    public float moveSpeed = 5.0f;
    public Transform ballPos;
    public GameManager gameManager;

   

    public void Update()
    {
       
        if(id == 3 && GameManager.instance.IsPlayer2Ai())
        {
            MoveAI();
        }
        else if (id == 2)
         {
           Input.GetAxis("movePlayer2");
            float movement = ProcessInput();
            Move(movement);
        }
        else
        {
            float movement = ProcessInput();
            Move(movement);
        }
        
    }
    
   /* private bool IsAi()
    {

        bool isPlayer2Ai = !bord1() && GameManager.instance.IsPlayer2Ai();
        return  isPlayer2Ai;
    }*/
    private void MoveAI()
    {
      
        Vector2 ballpos = ballPos.position; //GameManager.instance.ball.transform.position;
        int direction = ballPos.position.y > transform.position.y ? 1 : -1;
        Move(direction);
        ;
    }
   /* private float GetInput()
    {
        return isPlayer2Ai() ? Input.GetAxis(MovePlayer1InputName) : Input.GetAxis(MovePlayer2InputName);
    }*/


    private float ProcessInput()
    {
        float movement = 0f;
        switch (id)
        {
            case 1:
                movement = Input.GetAxis("movePlayer1");
                Move(movement);
                break;

            case 2:
                movement = Input.GetAxis("movePlayer2");
                Move(movement);
                break;

            case 3:

                //Debug.Log("normed   "+ballPos.position.normalized.y);

                //movement = ballPos.position.normalized.y;
              
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
