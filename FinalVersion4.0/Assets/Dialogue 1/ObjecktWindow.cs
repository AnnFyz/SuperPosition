using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjecktWindow : MonoBehaviour
{
    public GameObject window;



    public void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }
    


    
}
