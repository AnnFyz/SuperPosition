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
    public Health playerHealth;
    // win scene
    private void Awake()
    {
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(false);
        loseScreen.SetActive(false);
        indexScene++;
    }

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

        public void LoadScene()
    {
        SceneManager.LoadScene(indexScene);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
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

    public void TryAgain(int index)
    {
        LoadScene(index);
        playerHealth.currentHealth = 100;
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !inOptionsMenu)
        {
            PauseGame();
            pauseScreen.SetActive(true);
            inPauseMenu = true;
        }

        if (playerHealth.currentHealth <= 0)
        {
            loseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
