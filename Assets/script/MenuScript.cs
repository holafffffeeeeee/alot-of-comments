using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Canvas;
    public GameObject Back;
    public GameObject backgroundnyan;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Settings()
    {
        if (Application.isPlaying)
        {
            Canvas.SetActive(false);
            Back.SetActive(true);
            backgroundnyan.SetActive(true);
        }

        /*if(Back)
        {
            Canvas.SetActive(false) = gameObject.Back;
        }*/
    }
    public void BackButton()
    {
        Canvas.SetActive(true);
        Back.SetActive(false);
        backgroundnyan.SetActive(false);
    }
   
}      
