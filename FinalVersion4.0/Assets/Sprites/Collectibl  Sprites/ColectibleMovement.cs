using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectibleMovement : MonoBehaviour
{
   public float speed;
    public Transform[] PatrolPoints;
    public float waitTime;
    int currentPointIndex;
    bool once;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if (transform.position != PatrolPoints[currentPointIndex].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        }
        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
        }


    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);

        if (currentPointIndex + 1 < PatrolPoints.Length)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }

        once = false;

    }
}
