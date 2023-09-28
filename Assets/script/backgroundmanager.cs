using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    public GameObject background;

    public void Start()
    {
        if (gameManager.backgroundOnOff == GameManager.BackGroundOnOff.BackGroundOn)
            background.SetActive(true);

    }
    public void BackGroundOnOffClicked()
    {
        GameManager.instance.BackgroundOnOff();


    }
    private void ImageOnOrOf()
    {
        switch (GameManager.instance.backgroundOnOff)
        {
            case GameManager.BackGroundOnOff.BackGroundOn:
                GameManager.instance.backgroundOnOff = GameManager.BackGroundOnOff.BackGroundOff;
                break;

            case GameManager.BackGroundOnOff.BackGroundOff:
                GameManager.BackGroundOnOff.BackGroundOff = GameManager.instance.backgroundOnOff;
                break;
        }

    }
    // Update is called once per frame

}
