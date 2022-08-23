using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int indexScene;

    public void LoadScene()
    {
        SceneManager.LoadScene(indexScene++);
    }
}
