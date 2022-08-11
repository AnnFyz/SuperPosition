using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    public GameObject window;
    public bool inRange = false;



    private void Start()
    {
        ToggleWindow(false);
        inRange = false;
    }

     private void Update()
    {
        if(inRange)
        {
            ToggleWindow(true);
        }
       

        else
       {
            ToggleWindow(false);
       }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            inRange = false;
        }
    }


    public void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

}
