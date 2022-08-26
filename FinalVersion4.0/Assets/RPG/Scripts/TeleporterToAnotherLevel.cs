using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterToAnotherLevel : MonoBehaviour
{

    public int wantedKeyId;
    public bool WasUsedRightKey;
    public GameObject windowNoKey;
    public GameObject windowHasKey;
    public GameObject destinationPoint;
    public bool playerDetected;
    public GameObject player;
    public List<GameObject> allKeyArticles;
    public Slot slot;
    public int slotsIndex = 0;
    public GameManager gameManager;
    private void Start()
    {
        ToggleNoKey(false);
        ToggleHasKey(false);
        player = GameObject.FindGameObjectWithTag("Player");
        allKeyArticles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Slot"));
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void ToggleNoKey(bool show)
    {
        windowNoKey.SetActive(show);
    }
    public void ToggleHasKey(bool show)
    {
        windowHasKey.SetActive(show);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDetected = true;
            if (!WasUsedRightKey)
            {
                ToggleNoKey(playerDetected);
            }
            if (WasUsedRightKey)
            {
                ToggleHasKey(playerDetected);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDetected = false;

            if (!WasUsedRightKey)
            {
                ToggleNoKey(playerDetected);
            }
            if (WasUsedRightKey)
            {
                ToggleHasKey(playerDetected);
            }
        }
    }

   

    private void DestroyKeyArticle()
    {

        if (playerDetected)
        {
            for (int i = 0; i < allKeyArticles.Count; i++)
            {
                slot = allKeyArticles[i].GetComponent<Slot>();
                slotsIndex++;

                if (slot == null || slot.transform.childCount <= 0)
                {
                    continue;
                }
                if (slot.GetComponentInChildren<ItemUIDescription>().idKey == wantedKeyId)
                {
                    WasUsedRightKey = true;
                    ToggleNoKey(false);
                    slot.DropItem();

                }

            }
        }


    }

    private void Update()
    {
        if (playerDetected && Slot.isChecking)
        {
            DestroyKeyArticle();
        }


        if (playerDetected && Input.GetKeyDown(KeyCode.E) && WasUsedRightKey)
        {
            gameManager.LoadScene();//Teleport to another level
            player.transform.position = destinationPoint.transform.position;

        }
    }


}