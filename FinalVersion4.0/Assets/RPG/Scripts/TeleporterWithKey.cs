using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterWithKey : MonoBehaviour
{
    [SerializeField] private Transform destination;
    public int wantedKeyId;
    public bool WasUsedRightKey = false;
    public GameObject windowNoKey;
    public GameObject windowHasKey;
    public bool playerDetected;
    public GameObject player;
    public List<GameObject> allKeyArticles;
    public Slot slot;
    public int slotsIndex = 0;
    private void Start()
    {
        ToggleNoKey(false);
        ToggleHasKey(false);
        player = GameObject.FindGameObjectWithTag("Player");
        allKeyArticles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Slot"));
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

    //bool CheckCollectedObjects(int selectedArticleId)
    //{
        

    //    {
    //        foreach (var item in artickleId)
    //        {
    //            if (item == selectedArticleId)
    //            {
    //                if (item == wantedKeyId)
    //                {

    //                    WasUsedRightKey = true;
    //                    return true;
    //                }
    //            }


    //        }

    //    }

    //    return false;
    //}

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


        if (destination != null && playerDetected && Input.GetKeyDown(KeyCode.E) && WasUsedRightKey)
        {
            player.transform.position = new Vector3(destination.position.x, destination.position.y);

        }
    }


}
