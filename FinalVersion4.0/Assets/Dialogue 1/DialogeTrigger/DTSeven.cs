using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTSeven : MonoBehaviour
{
    public DSeven dialogueScript;

    private bool playerDetected;

    //Detect trigger with Player

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we triggered the player enable playerdetected and show indicator
        if (collision.tag == "Player")
        {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
            Debug.Log("Lol it dose work ");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //if we lost trigger with the player disable playerdetected and hide indicator
        if (collision.tag == "Player")
        {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
            dialogueScript.EndDialogue();
        }
    }
    //while detected if we interact start dialogue
    private void Update()
    {
        if (playerDetected && Input.GetMouseButtonDown(0))
        {
            dialogueScript.StartDialogue();
        }
    }

}
