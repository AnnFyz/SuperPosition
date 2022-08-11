using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMovmentPlayer : MonoBehaviour
{
     [Header("Horizontal Movement")]
    public float speed;
    private float Move;
    public float JumpPower;


    [Header("Components")]
    public Rigidbody2D rb;


    void Start()
    {

    }


    void Update()
    {

    
    }

    private void FixedUpdate()
    {

        moveCharacter();
        fly();

       
    }



    void moveCharacter()
    {
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
    }


    void fly ()
    {
        if(Input.GetKey(KeyCode.W))
        {

            rb.velocity = Vector2.up * JumpPower;
        }
    }
    


}
