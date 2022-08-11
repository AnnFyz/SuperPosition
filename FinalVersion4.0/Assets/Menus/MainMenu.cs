using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceeneIndex;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
       Debug.Log("Quit");
        Application.Quit();
       
    }

    public void Restard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
