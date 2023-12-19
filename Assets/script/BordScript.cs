using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BordScript : MonoBehaviour
{
    public Rigidbody2D rb2d; //rigidbody rb2d = rigidbody2D
    public float id; //id ska vara så om bordet har id 2 ska playerVSplayer
    public float moveSpeed = 5.0f; //hur snappt den går  
    public Transform ballPos; // den spåra vart bollen är ock flyta dit
    public GameManager gameManager; // reference till gamemanager

   // AI använder id 3 för att röra på sig
   // detta är också  styr hjulet så om man ändra här du ändra AI 

    public void Update()
    {
       
        if(id == 3 && GameManager.instance.IsPlayer2Ai())
        {
            MoveAI();
        }
       /* else if (id == 2)
         {
           Input.GetAxis("movePlayer2");
            float movement = ProcessInput();
            Move(movement);
        }*/
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
   // den gör så den tracka bollen posititon ock flyta sig dit 
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

    // här försökte jag får en input från spelaren genom att ge det ett id för varje case s
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
  // detta är gas / mortorn så den converta vecotor 2 till movement speed 
   private void Move(float movement)
    {

       Vector2 valo = rb2d.velocity;
        valo.y = moveSpeed * movement;
        rb2d.velocity = valo;
    }
}
