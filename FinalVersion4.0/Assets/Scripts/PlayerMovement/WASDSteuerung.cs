using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WASDSteuerung : MonoBehaviour

{
    public Rigidbody2D rB;

    public int moveSpeed;

    public bool onGround = false;
    public float groundLength = 2f;

    public Vector3 colliderOffset;
    public LayerMask groundLayer;
    //rivate InventoryMelina inventory;
    Vector2 movement;

    public int damage;
    //public GameObject dieScreen;


    //[SerializeField] private UI_Inventory uiInventory;

    public Animator animator;

    public Color oldColor;

    //private void Awake()
    //{
    //    inventory = new InventoryMelina();
    //    uiInventory.setInventory(inventory);
    //}

    void Update()
    {
        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");



        movement = new Vector2(moveX, moveY).normalized;

    }

    private void FixedUpdate()
    {

        rB.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

        animator.SetFloat("AnimMoveX", movement.x);
        animator.SetFloat("AnimMoveY", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
        //animator.SetFloat("flyingSpeed", movement.magnitude);

        if (movement.x > 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (movement.x < 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        if (onGround)
        {
            animator.SetBool("onGround", true);
        }
        else
        {
            animator.SetBool("onGround", false);
        }


        if (damage > 99)
        { 
            Die();
            //dieScreen.SetActive(true);
        }
    }

    void Die()
    {
        moveSpeed = 0;
    }
       

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }



    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    oldColor = collision.gameObject.GetComponent<Image>().color;
    //    collision.gameObject.GetComponent<Image>().color = new Color32(255, 0, 225, 255);
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    collision.gameObject.GetComponent<Image>().color  = oldColor;
    //}


}
