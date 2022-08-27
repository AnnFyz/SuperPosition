using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private NewInventory inventory;
    public int slotIndex;
    public ItemUIDescription articleId;
    public static int lastArticleId;
    public static int selectedArticleId = -1;
    public static bool isChecking;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<NewInventory>();
    }

    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.isFull[slotIndex] = false;
        }

        
    }
    public void DropItem() // if you are in range and it´s a right item
    {
         foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
               
            }
       

    }

  
    public void SelectArticle()
    {
        articleId = GetComponentInChildren<ItemUIDescription>();
        if (articleId == null)
            return;
        
        lastArticleId = selectedArticleId;
        selectedArticleId = articleId.idArticle;
        Debug.Log("ArticleIsSelected " + selectedArticleId); // lastSelected newSelected
        isChecking = true;
    }
}
