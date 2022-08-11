using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DNine : MonoBehaviour
{
    //Fields
    //Window
    public GameObject window;
    //Indicator
    public GameObject indicator;
    //Text component
    public TMP_Text dialogueText;
    //Dialogues list
    public List<string> dialogues;
    //writing speed
    public float writingSpeed;
    //Index on dialogue
    private int index;
    //Character index
    private int charIndex;
    //started boolean
    public bool started;
    //wait for next boolean
    public bool isPickleInInventory;
    private bool waitForNext;

    public Item item;

    public Animator Anim;

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }





    public void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }


    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }
    //Start Dialogue
    public void StartDialogue()
    {
        if (started)
            return;
        Anim.SetBool("DialogeStarted", true);

        //Boolean that indicate that we have started
        started = true;
        //Show window
        ToggleWindow(true);
        //hide the indicator
        ToggleIndicator(false);
        //Start with first dialogue
        GetDialogue(0);
    }



    public void GetDialogue(int i)
    {
        //start index at zweo
        index = i;
        //Reset the character index
        charIndex = 0;
        //clear the dialogue component text
        dialogueText.text = string.Empty;
        //start writing
        StartCoroutine(Writing());
    }


    //End Dialogue
    public void EndDialogue()
    {

        Anim.SetBool("DialogeStarted", false);
        started = false;
        waitForNext = false;
        StopAllCoroutines();
        //Hide the window
        ToggleWindow(false);
    }
    //writing logic
    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialogues[index];
        //Write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase the character index
        charIndex++;
        //make sure u have reached the end of the sentence
        if (charIndex < currentDialogue.Length)
        {
            //wait x seconds
            yield return new WaitForSeconds(writingSpeed);
            //Restart the same process
            StartCoroutine(Writing());

        }
        else
        {
            //end this sentence and wait for next one
            waitForNext = true;
        }
        //wait x seconds
        yield return new WaitForSeconds(writingSpeed);
        //restart same process
        StartCoroutine(Writing());
    }


    private void Update()
    {
        if (!started)
            return;

        if (waitForNext && Input.GetMouseButtonDown(0))
        {
            waitForNext = false;
            index++;

            if (index < dialogues.Count - 1)
            {
                GetDialogue(index);
            }
            else
            {
                ToggleIndicator(true);
                EndDialogue();
            }

        }
    }
}
