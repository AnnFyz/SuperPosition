using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    Vector3 targetPosition;
    public float speed;
    public bool isAttacked;

    WASDSteuerung steuerung;
    [SerializeField] GameObject Player;
    Health healthComponent;

    void Start()
    {

        steuerung = FindObjectOfType<WASDSteuerung>();
        targetPosition = FindObjectOfType<WASDSteuerung>().transform.position;
        healthComponent = steuerung.GetComponent<Health>();

    }

    private void Update()
    {

        
        if (Vector2.Distance(transform.position, targetPosition) < 8)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }   
      

        if(transform.position == targetPosition)
        {
            Destroy(gameObject);
            steuerung.damage++;
            //steuerung.animator.SetBool("Damage", true);
            Debug.Log("Animation");
            isAttacked = true;

        }
        else
        {
            //steuerung.animator.SetBool("Damage", false);
            isAttacked = false;
        }
       
        if (healthComponent != null)
        {
            healthComponent.TakeDamage(1);
        }
    }
}
