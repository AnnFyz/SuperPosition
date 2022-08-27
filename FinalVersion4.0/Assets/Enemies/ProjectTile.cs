using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed;
    public bool isAttacked;

    WASDSteuerung steuerung;
    [SerializeField] GameObject Player;
    Health healthComponent;
    public GameObject player;
    public Animator playerAnim;

    void Start()
    {

        steuerung = FindObjectOfType<WASDSteuerung>();
        targetPosition = FindObjectOfType<WASDSteuerung>().transform.position;
        healthComponent = steuerung.GetComponent<Health>();
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerAnim = player.GetComponentInChildren<Animator>();
       

    }

    private void Update()
    {

        
        //if (Vector2.Distance(transform.position, targetPosition) <= 10)
        //{
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        //}   
      

        if(transform.position == targetPosition)
        {
            Destroy(gameObject);
            steuerung.damage++;
            //playerAnim.SetBool("Damage", true);
            Debug.Log("Animation");
            isAttacked = true;

            if (healthComponent != null)
            {
                healthComponent.TakeDamage(5);
                //healthComponent.isPlayerAttacked = true;
            }
            
        }
        else
        {
            //playerAnim.SetBool("Damage", false);
            isAttacked = false;
            //healthComponent.isPlayerAttacked = false;
            Destroy(gameObject, 1f);
        }
       
       
    }
}
//private void OnTriggerEnter2D(Collider2D collision)
//{
//    if(collision.tag == "Player")
//    {

//        steuerung.damage++;
//        //playerAnim.SetBool("Damage", true);
//        Debug.Log("Animation");
//        isAttacked = true;

//        if (healthComponent != null)
//        {
//            healthComponent.TakeDamage(5);
//            healthComponent.isPlayerAttacked = true;
//        }

//    }
//}

//private void OnTriggerExit2D(Collider2D collision)
//{
//    if (collision.tag == "Player")
//    {
//        if (healthComponent != null)
//        {
//            healthComponent.isPlayerAttacked = false;
//        }
//        Destroy(gameObject);
//    }
//    }

