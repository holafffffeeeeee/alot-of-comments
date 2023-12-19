using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameManager gameManager;   // refrence till gamemanager
    public GameObject Canvas; // refrence till canvas
    public GameObject Back;  // refrence till back button
    public GameObject backgroundnyan; // refrence till  bilden
    public GameObject Back2; // refrence till back button 2
    // för att byta scen till spelet
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
     // settings menyn och stuff
    public void Settings()
    {
        if (Application.isPlaying)
        {
            Canvas.SetActive(false);
            Back.SetActive(true);
            backgroundnyan.SetActive(true);
        }

    }
    // credits menyn
    public void Credits()
    { 
        if (Application.isPlaying) 
        {
            Canvas.SetActive(false);
           Back2.SetActive(true);
        } 
    }
    // back button menyn
    public void BackButton()
    {
        Canvas.SetActive(true);
        Back.SetActive(false);
        backgroundnyan.SetActive(false);
    }
    //back button 2 knapp typ
   public void back2()
    { 
        Canvas.SetActive(true);
        Back2.SetActive(false);
    }
    // tutorial
    public void OpenURL(string link)
    {
        
        Application.OpenURL(link);
    }
}      
