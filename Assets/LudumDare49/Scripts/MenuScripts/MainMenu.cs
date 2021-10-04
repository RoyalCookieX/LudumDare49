using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start(){
        Time.timeScale = 1f;
    }
    //public Animator intro;

    //public float transitionTime = 2f;

    //public GameObject introScreen;

    public void Menu()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        /*introScreen.SetActive(true);
        StartCoroutine(LoadIntro(SceneManager.GetActiveScene().buildIndex + 1));*/
    }

    /*IEnumerator LoadIntro(int levelIndex)
    {
        intro.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }*/

    public void Exit()
    {
        Application.Quit();
    }

    public void Death()
    {
        SceneManager.LoadScene(2);
    }
    public void Options()
    {
        SceneManager.LoadScene(3);
    }
}
