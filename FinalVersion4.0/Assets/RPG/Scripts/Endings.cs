using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endings : MonoBehaviour
{
    public int goodArticleId;
    public int badArticleId;
    public bool isPlayerInRange;
    public GameObject ToggleIndicator;
    public GameObject goodArticleButton;
    public GameObject badArticleButton;
    NewInventory inventory;
    public List<GameObject> allUIArticles;
    public bool isBadArtickle = false;
    public bool isGoodArtickle = false;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<NewInventory>();
        allUIArticles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Slot"));
        goodArticleButton.SetActive(false);
        badArticleButton.SetActive(false);
        ToggleIndicator.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we triggerd the player enable playerdeteced and show indicator
        if (collision.tag == "Player")
        {
            isPlayerInRange = true;
            ToggleIndicator.SetActive(isPlayerInRange);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If we lost trigger  with the player disable playerdeteced and hide indicator
        if (collision.tag == "Player")
        {
            isPlayerInRange = false;
            ToggleIndicator.SetActive(isPlayerInRange);
            goodArticleButton.SetActive(false);
            badArticleButton.SetActive(false);
        }
    }
    void CheckGoodArticle() // add change to dialogue state FIX CODE HERE
    {
        if (isPlayerInRange)
        {
            for (int i = 0; i < allUIArticles.Count; i++)
            {
                Slot slot = allUIArticles[i].GetComponent<Slot>();
                if (slot == null || slot.transform.childCount <= 0)
                {
                    continue;
                }
                if (slot.GetComponentInChildren<ItemUIDescription>().idArticle == goodArticleId)
                {
                    ToggleIndicator.SetActive(false);
                    goodArticleButton.SetActive(true);
                }

            }
        }
    }
    void CheckBadArticle() // add change to dialogue state FIX CODE HERE
    {
        if (isPlayerInRange)
        {
            for (int i = 0; i < allUIArticles.Count; i++)
            {
                Slot slot = allUIArticles[i].GetComponent<Slot>();
                if (slot == null || slot.transform.childCount <= 0)
                {
                    continue;
                }
                if (slot.GetComponentInChildren<ItemUIDescription>().idArticle == badArticleId)
                {
                    ToggleIndicator.SetActive(false);
                    badArticleButton.SetActive(true);
                }

            }
        }
    }


    void Update()
    {

        if (isPlayerInRange && Slot.isChecking)
        {

           
            CheckGoodArticle();
            CheckBadArticle();
        }

    }
}
