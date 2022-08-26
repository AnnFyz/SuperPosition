using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int indexScene;
    public static bool playGame = true;
    public bool inOptionsMenu = false;
    public bool inPauseMenu = false;
    public GameObject pauseScreen;
    public GameObject loseScreen;
    public GameObject optionsScreen;

    // win scene
    private void Awake()
    {
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(false);
        indexScene++;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(indexScene);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(false);
    }

    public void ShowOptions()
    {
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(true);
        inOptionsMenu = true;
    }

    public void ToPauseScreen()
    {
        pauseScreen.SetActive(true);
        optionsScreen.SetActive(false);
        inOptionsMenu = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !inOptionsMenu)
        {
            PauseGame();
            pauseScreen.SetActive(true);
            inPauseMenu = true;
        }
    }
}
