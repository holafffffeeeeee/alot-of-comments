using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;// reference till gamemanager
    public GameObject background; // detta är en refrence il et game objet i menyn

    // detta är till för kunna ändra bakgrund ingame så om klicka på knappen so blir background off dom man klicka på den ska den vara ON
    public void Start()
    {
        if (gameManager.backgroundOnOff == GameManager.BackGroundOnOff.BackGroundOn)
            background.SetActive(true);

    }
    // det är for att unity ska hitta den
    public void BackGroundOnOffClicked()
    {
        GameManager.instance.BackgroundOnOff();


    }
    // det är för at byta mellan knappar
    public void ImageOnOrOf()
    {
        switch (GameManager.instance.backgroundOnOff)
        {
            case GameManager.BackGroundOnOff.BackGroundOn:
                GameManager.instance.backgroundOnOff = GameManager.BackGroundOnOff.BackGroundOff;
                break;

            case GameManager.BackGroundOnOff.BackGroundOff:
                GameManager.instance.backgroundOnOff = GameManager.BackGroundOnOff.BackGroundOn;
                break;
        }

    }
    // Update is called once per frame

}
