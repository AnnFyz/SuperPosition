using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float speed;
    private float Move;




    public float jumpForce = 9f;
    public float gravity = 1;
    public float fallMultiplier = 5;
    public float linearDrag = 4f;
    public float jumpDelay = 0.25f;
    private float jumpTimer;

    public Vector3 colliderOffset;

    public LayerMask groundLayer;

    float InputHorizontal;
    float InputVertical;

    [Header("Components")]
    public Rigidbody2D rb;


    public bool onGround = false;
    public float groundLength = 1f;

    void Start()
    {

    }


    void Update()
    {


        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);


        if (Input.GetButtonDown("Jump"))
        {
            jumpTimer = Time.time + jumpDelay;
        }


    }

    private void FixedUpdate()
    {

        moveCharacter();

        if (jumpTimer > Time.time && onGround)
        {
            Jump();
        }

        ModifyPhisics();

        if (InputHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        if (InputHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }


       
    }



    void moveCharacter()
    {


        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
    }
    void Jump()
    {
        
        
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpTimer = 0;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }





    void ModifyPhisics()
    {

        if (onGround)
        {
            rb.gravityScale = 0f;
        }

        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;

            if (rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;
            }
            else if (rb.velocity.y > 0 && !Input.GetButtonDown("Jump"))
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
    }




}
