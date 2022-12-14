using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    NewInventory inventory;
    public GameObject itemButton;
    public int id;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<NewInventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slotsObj.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                   
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slotsObj[i].transform, false);
                    inventory.FillArtickleIdList();
                    Destroy(gameObject);
                    break;  //add item
                }
            }
        }
    }
}
