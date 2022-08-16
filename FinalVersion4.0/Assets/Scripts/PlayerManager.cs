using System;
using UnityEngine;
using CodeMonkey.Utils;
public class PlayerManager : MonoBehaviour
{

    public static PlayerManager Instance { get; private set; }
    //[SerializeField] private MaterialTintColor materialTintColor;
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;

    [SerializeField] private DialogueOne dialogue1;
    [SerializeField] private DialogueTow dialogue2;
    [SerializeField] private DialogueTree dialogue3;
    [SerializeField] private DFor dialogue4;
    [SerializeField] private DFive dialogue5;
    [SerializeField] private DSix dialogue6;
    [SerializeField] private DSeven dialogue7;
    [SerializeField] private DEight dialogue8;
    [SerializeField] private DNine dialogue9;

    [SerializeField] private PlayerTeleport playerTeleport;

    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;
    public GameObject NPC4;
    public GameObject NPC5;
    public GameObject NPC6;
    public GameObject NPC7;
    public GameObject NPC8;
    public GameObject NPC9;

    private ItemWorld itemWorld;
    public bool isPickable = false;



    private void Awake()
    {
        Instance = this;
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);


    }
    private void Update()
    {
        //PickUp();
    }

    //void PickUp()
    //{
    //    if (isPickable && itemWorld != null)
    //    {
    //        // Touching Item
    //        inventory.AddItem(itemWorld.GetItem());
    //        itemWorld.DestroySelf();
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collider)
    {
        itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            isPickable = true;
            //// Touching Item
            //inventory.AddItem(itemWorld.GetItem());
            //itemWorld.DestroySelf();
        }
        //else
        //{
        //    isPickable = false;
        //}
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        isPickable = false;
    }
    //private void OnTriggerStay2D(Collider2D collider)
    //{
    //    ItemWorld itemWorld = collider.GetComponent<ItemWorld>();

    //    //if (itemWorld != null && Input.GetMouseButtonDown(0))
    //    //{
    //    //    // Touching Item
    //    //    Debug.Log("COLLIDER");
    //    //    inventory.AddItem(itemWorld.GetItem());
    //    //    itemWorld.DestroySelf();
    //    //}
    //}

    public void UseItem(Item item)
    {
        switch (item.itemType)
        {

            case Item.ItemType.Pickle:
                //FlashGreen();
                if (dialogue2.started == true)
                {
                    dialogue2.GetDialogue(3);
                    inventory.RemoveItem(new Item { itemType = Item.ItemType.Pickle, amount = 1 });
                    ItemWorld.SpawnItemWorld(NPC2.transform.position, new Item { itemType = Item.ItemType.KeyForOrangePortal });
                }
                break;
            case Item.ItemType.KeyForPinkPortal:
                //FlashBlue();



                if (playerTeleport.PinkTeleporter != null)
                {
                    inventory.RemoveItem(new Item { itemType = Item.ItemType.KeyForPinkPortal, amount = 1 });
                    playerTeleport.isPinkTeleporterOpen = true;
                }
                break;
            case Item.ItemType.KeyForOrangePortal:
                if (playerTeleport.OrangeTeleporter != null)
                {
                    inventory.RemoveItem(new Item { itemType = Item.ItemType.KeyForOrangePortal, amount = 1 });
                    playerTeleport.isOrangeTeleporterOpen = true;
                }
                break;


            case Item.ItemType.KeyForGreenPortal:
                if (playerTeleport.GreenTeleporter != null)
                {
                    inventory.RemoveItem(new Item { itemType = Item.ItemType.KeyForGreenPortal, amount = 1 });
                    playerTeleport.isGreenTeleporterOpen = true;
                }
                break;
            case Item.ItemType.RabbitPuppet:
                if (dialogue1.started == true)
                {
                    dialogue1.GetDialogue(3);
                    inventory.RemoveItem(new Item { itemType = Item.ItemType.RabbitPuppet, amount = 1 });
                    ItemWorld.SpawnItemWorld(NPC1.transform.position, new Item { itemType = Item.ItemType.KeyForPinkPortal });
                }
                break;
            case Item.ItemType.Parfume:
                if (dialogue4.started == true)
                {
                    dialogue4.GetDialogue(3);
                    inventory.RemoveItem(new Item { itemType = Item.ItemType.Parfume, amount = 1 });
                    ItemWorld.SpawnItemWorld(NPC4.transform.position, new Item { itemType = Item.ItemType.KeyForPinkPortal });
                }
                break;

            case Item.ItemType.Fisch:
                if (dialogue7.started == true)
                {
                    dialogue7.GetDialogue(3);
                    inventory.RemoveItem(new Item { itemType = Item.ItemType.Fisch, amount = 1 });
                    ItemWorld.SpawnItemWorld(NPC7.transform.position, new Item { itemType = Item.ItemType.KeyForPinkPortal });
                }
                break;

            case Item.ItemType.Bottel:
                if (dialogue8.started == true)
                {
                    dialogue8.GetDialogue(3);
                    inventory.RemoveItem(new Item { itemType = Item.ItemType.Bottel, amount = 1 });
                    ItemWorld.SpawnItemWorld(NPC8.transform.position, new Item { itemType = Item.ItemType.KeyForOrangePortal });
                }
                break;

            case Item.ItemType.Brosche:
                if (dialogue6.started == true)
                {
                    dialogue6.GetDialogue(3);
                    inventory.RemoveItem(new Item { itemType = Item.ItemType.Brosche, amount = 1 });
                    ItemWorld.SpawnItemWorld(NPC6.transform.position, new Item { itemType = Item.ItemType.KeyForGreenPortal });
                }
                break;

            case Item.ItemType.CatMint:
                if (dialogue3.started == true)
                {
                    dialogue3.GetDialogue(3);
                    inventory.RemoveItem(new Item { itemType = Item.ItemType.CatMint, amount = 1 });
                    ItemWorld.SpawnItemWorld(NPC3.transform.position, new Item { itemType = Item.ItemType.KeyForGreenPortal });
                }
                break;

            case Item.ItemType.Macdonalds:
                if (dialogue5.started == true)
                {
                    dialogue5.GetDialogue(3);
                    inventory.RemoveItem(new Item { itemType = Item.ItemType.Macdonalds, amount = 1 });
                    ItemWorld.SpawnItemWorld(NPC5.transform.position, new Item { itemType = Item.ItemType.KeyForOrangePortal });
                }
                break;
        }
    }

  

    public Vector3 GetPosition()
    {
        return transform.position;
    }

}
