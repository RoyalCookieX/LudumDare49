using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    /* public void Play() 
     {
         SceneManager.LoadScene();
     }*/

    public void Exit()
    {
        Application.Quit();
    }

    public void Death()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        SceneManager.LoadScene(2);
    }
}
