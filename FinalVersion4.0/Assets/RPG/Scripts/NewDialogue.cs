using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewDialogue : MonoBehaviour
{
    //Fields
    //Window
    public bool IsStartedDialogEnded = false;
    public bool wasClickedYes = false;
    public bool articleWasRecieved = false;
    public bool IslastPhrase = false;
    public GameObject window;
    public GameObject answerButtons;
    //Indicator
    public GameObject indicator;
    //Text component
    public TMP_Text dialogueText;
    //Dialogues list
    public List<string> startDialogues;
    public List<string> inProgressDialogues;
    public List<string> keyDialogues;
    public List<string> thanksgivingDialogues;
    public List<string> currentDialogue;
    //Writing speed
    public float writingSpeed;
    //Index on dialogue
    private int index;
    //Character index
    private int charIndex;
    //Started boolean
    private bool started;
    //Wait for next boolean
    private bool waitForNext;


    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
        ToggleAnswerOptionsButtons(false);
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }
    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    private void ToggleAnswerOptionsButtons(bool show)
    {
        answerButtons.SetActive(show);
    } 

    public void ClickedYes()
    {
        wasClickedYes = true;
        currentDialogue = inProgressDialogues;
        EndDialogue();
        StartDialogue();
        //ToggleAnswerOptionsButtons(false);
    }

    public void ClickedNo()
    {
        EndDialogue();
    }

    public void ArticleRecieved()
    {
        articleWasRecieved = true;
        currentDialogue = keyDialogues;
        EndDialogue();
        StartDialogue();
    }

    public void SayThanks()
    {
        IslastPhrase = true;
        currentDialogue = thanksgivingDialogues;

    }

    //Start Dialogue
    public void StartDialogue()
    {
        if (started)
            return;
        //check which dialog to start now
        if (!IsStartedDialogEnded && !wasClickedYes && !articleWasRecieved && !IslastPhrase)
        {
            currentDialogue = startDialogues;
        }
        //Boolean to indicate that we have started
        started = true;
        //Show the window
        ToggleWindow(true);
        //hide the indicator
        ToggleIndicator(false);
        //Start with first dialogue
        GetDialogue(0, currentDialogue);
    }

    private void GetDialogue(int i, List<string> dialog)
    {
        //start index at zero
        index = i;
        //Reset the character index
        charIndex = 0;
        //clear the dialogue component text
        dialogueText.text = string.Empty;
        //Start writing
        StartCoroutine(Writing(dialog));
    }

    //End Dialogue
    public void EndDialogue()
    {
        //Stared is disabled
        started = false;
        //Disable wait for next as well
        waitForNext = false;
        //Stop all Ienumerators
        StopAllCoroutines();
        //Hide the window
        ToggleWindow(false);
        ToggleAnswerOptionsButtons(false);
    }
    //Writing logic
    IEnumerator Writing(List<string> dialog)
    {
        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialog[index];
        //Write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase the character index 
        charIndex++;
        //Make sure you have reached the end of the sentence
        if(charIndex < currentDialogue.Length)
        {
            //Wait x seconds 
            yield return new WaitForSeconds(writingSpeed);
            //Restart the same process
           
            StartCoroutine(Writing(dialog));
        }
        else
        {
            //End this sentence and wait for the next one
            waitForNext = true;
        }        
    }

    private void Update()
    {
        if (!started)
            return;

        if(waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;

            //Check if we are in the scope fo dialogues List
            if(index < currentDialogue.Count)
            {
                //If so fetch the next dialogue
                GetDialogue(index, currentDialogue);

                if (currentDialogue == startDialogues && index == currentDialogue.Count - 1) //show two buttons yes and no, to change a start state and trigger a new dialogue loop
                {
                    //IsStartedDialogEnded = true;
                    ToggleAnswerOptionsButtons(true);
                }
            }
            else
            {
                //If not end the dialogue process
                //IsStartedDialogEnded = false;
                ToggleIndicator(true);
                EndDialogue();
            }            
        }
    }

}
