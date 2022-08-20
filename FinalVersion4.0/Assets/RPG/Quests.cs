using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
    public int desiredObjectId;
    public GameObject desiredObj;
    public List<GameObject> allUIArticles;
    public GameObject keyUI;
    public bool isKeyWasGiven = false;
    NewInventory inventory;
    NewDialogueTrigger isPlayerInRange;
    NewDialogue dialogue;
    public bool isRightArtickle = false;
    public bool isUIArticleCanBeDropped = false;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<NewInventory>();
        isPlayerInRange = GetComponent<NewDialogueTrigger>();
        dialogue = GetComponentInChildren<NewDialogue>();
        allUIArticles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Slot"));
    }
    public void CheckArticleAndGiveKey() // add change to dialogue state FIX CODE HERE
    {
        if (isPlayerInRange.playerDetected && isRightArtickle && !isKeyWasGiven)
        {
            isUIArticleCanBeDropped = true;
            for (int i = 0; i < inventory.slotsObj.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;

                    dialogue.ArticleRecieved();
                    Instantiate(keyUI, inventory.slotsObj[i].transform, false);
                    isKeyWasGiven = true; // to give a key only once
                    break;  //add article
                }
            }
        }
    }

    private void DestroyUIArticle()
    {
        if (isPlayerInRange.playerDetected && isRightArtickle && isKeyWasGiven)
        {
            for (int i = 0; i < allUIArticles.Count; i++)
            {
                Slot slot = allUIArticles[i].GetComponent<Slot>();
                if (slot == null || slot.transform.childCount <= 0)
                {
                    return;
                }
                if(slot.GetComponentInChildren<ItemUIDescription>().idArticle == desiredObjectId)
                {
                    slot.DropItem();
                    dialogue.SayThanks();
                }
                
            }
        }


    }
    
    private void Update()
    {


        if (isPlayerInRange.playerDetected && Slot.isChecking)
        {
            isRightArtickle = inventory.CheckCollectedObjects(desiredObjectId, Slot.selectedArticleId);
            CheckArticleAndGiveKey();
            DestroyUIArticle();
        }
    }
}
