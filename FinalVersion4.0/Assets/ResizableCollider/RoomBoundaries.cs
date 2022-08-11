using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBoundaries : MonoBehaviour
{
    [SerializeField] int roomIndex;
    //[SerializeField] GameObject player;
   // [SerializeField] WASDSteuerung playerMovement;
   // [SerializeField] SpriteRenderer playerSprite;

    public static bool isCollidesWithOtherRoom = false;
    static Vector2 roomBounds;
    float offsetX;
    float offsetY;

    public bool isTopBlocked;
    public bool isBottomBlocked;
    public bool isRightBlocked;
    public bool isLeftBlocked;


    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerMovement = player.GetComponent<WASDSteuerung>();
        //playerSprite = player.GetComponent<SpriteRenderer>();
        roomBounds = transform.position;
        //offsetX = player.transform.localScale.x / 2;
       // offsetY = player.transform.localScale.y / 2;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //playerMovement.isPlayerInRoom = true;
            //playerSprite.color = new Color(255, 255, 255);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //playerMovement.isPlayerInRoom = false;
        //playerSprite.color = new Color(75, 82, 192);

    }
}
