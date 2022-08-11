using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering.Universal;
using TMPro;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour {
    //Player player;

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item) {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item) {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDir * 1f, item);
        itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 3f, ForceMode2D.Impulse);
        return itemWorld;

    }

    public static ItemWorld Instance { get; private set; }
    [SerializeField] private UI_Inventory uiInventory;

    public bool itemDetected;
    private Inventory inventory; 
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        itemDetected = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        itemDetected = false;
    //    }
    //}
    //private void Update()
    //{
    //    if (itemDetected && Input.GetMouseButtonDown(0))
    //    {
    //        //inventory.AddItem(item);
    //        Destroy(gameObject);
    //    }
    //}
    // private void OnMouseDown()
    // {
    //     if (itemDetected)
    //     {
    //         //inventory.AddItem(GetItem());
    //         //DestroySelf();
    //         Destroy(this);
    //     }
    // }


    private Item item;
    private SpriteRenderer spriteRenderer;
    private Light2D light2D;
    private SpriteRenderer windowSprite;

    private void Awake() {
       //uiInventory = GameObject.FindGameObjectWithTag("UIInventar").GetComponent<UI_Inventory>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        light2D = gameObject.AddComponent<Light2D>();
        light2D.intensity = 1f;

        Instance = this;
        //uiInventory.SetInventory(inventory);
        //light2D = transform.Find("Light").GetComponent<Light2D>();
        //windowSprite = transform.Find("Window").GetComponent<SpriteRenderer>();
    }

    public void SetItem(Item item) {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        //light2D.color = item.GetColor();

    }

    public Item GetItem() {
        return item;
    }

    public void DestroySelf() {
        Destroy(gameObject);
    }

}
