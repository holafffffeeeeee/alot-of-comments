using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;// reference till gamemanager
    public GameObject background; // detta �r en refrence il et game objet i menyn

    // detta �r till f�r kunna �ndra bakgrund ingame s� om klicka p� knappen so blir background off dom man klicka p� den ska den vara ON
    public void Start()
    {
        if (gameManager.backgroundOnOff == GameManager.BackGroundOnOff.BackGroundOn)
            background.SetActive(true);

    }
    // det �r for att unity ska hitta den
    public void BackGroundOnOffClicked()
    {
        GameManager.instance.BackgroundOnOff();


    }
    // det �r f�r at byta mellan knappar
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
