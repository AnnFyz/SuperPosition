using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BottonHandler : MonoBehaviour
{
    public Button button;
    public int indexNextScene;
    static int mainSceneIndex = 0;
    public bool isItOptionsMenu;

    public GameObject optionsMenu;
    public GameObject mainMenu;

    public void LoadNewScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        if (optionsMenu && mainMenu != null)
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
           
        }
    }

    public void ToOptionsMenu()
    {
        if(optionsMenu && mainMenu != null)
        {
            optionsMenu.SetActive(true);
            mainMenu.SetActive(false);
            
        }
       
    }
}
