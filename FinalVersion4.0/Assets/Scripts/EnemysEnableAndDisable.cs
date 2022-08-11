using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysEnableAndDisable : MonoBehaviour
{
    public bool isEnemyInRoom;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isEnemyInRoom = true;
            other.gameObject.GetComponent<EnemyBehavior>().isEnemyInRoom = true;
           
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isEnemyInRoom = true;
            other.gameObject.GetComponent<EnemyBehavior>().isEnemyInRoom = false;
        }
    }

}
