using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Canvas;
    public GameObject Back;
    public GameObject backgroundnyan;
    public GameObject Back2;
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

    }
    public void Credits()
    { 
        if (Application.isPlaying) 
        {
            Canvas.SetActive(false);
           Back2.SetActive(true);
        } 
    }
    public void BackButton()
    {
        Canvas.SetActive(true);
        Back.SetActive(false);
        backgroundnyan.SetActive(false);
    }
   public void back2()
    { 
        Canvas.SetActive(true);
        Back2.SetActive(false);
    }
    public void OpenURL(string link)
    {
        
        Application.OpenURL(link);
    }
}      
