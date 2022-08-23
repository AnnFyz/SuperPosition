using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public bool isEnemyInRoom = false;
    public GameObject animObj;
    public float speed;
    Transform[] PatrolPoints;
    public float waitTime;
    public float startWaitTime;

    int currentPointIndex;
    bool once;
    public float distance = 4f;
    

    //public Transform target;
    public GameObject projectiele;
    public float timebetweenShots;
    private float nextShotTime;

    public Animator anim;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public bool isAttacked = false;

    public GameObject player;
    public Animator playerAnim; 

    Health playersHealth;
    // Start is called before the first frame update
    void Start()
    {
        moveSpot.position = new Vector2(Random.RandomRange(minX, maxX), Random.RandomRange(minY, maxY));
        animObj = transform.Find("Animation").gameObject;
        animObj.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponentInChildren<Animator>();
        playersHealth = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyInRoom)
        {
            Attack();
            animObj.SetActive(true);
        }
        else
        {
            isAttacked = false;
            RandomeMove();
            animObj.SetActive(false);
        }
       


    }

 

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, minX, maxX);
        viewPos.y = Mathf.Clamp(viewPos.y, minY, maxY);
        transform.position = viewPos;
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

    void RandomeMove()
    {

        if (Vector2.Distance(transform.position, player.transform.position) > distance * 1.5f || !isAttacked) //RANDOM MOVE // ADD 
        {
            //if player is not in radius move between patrol points
            isAttacked = false;
            playersHealth.isPlayerAttacked = false;

            anim.SetBool("IsAttacking", false);
            //playerAnim.SetBool("IsAttacking", false);

            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f || !isEnemyInRoom) //RANDOM MOVE
            {
                if (waitTime <= 0)
                {
                    moveSpot.position = new Vector2(Random.RandomRange(minX, maxX), Random.RandomRange(minY, maxY));
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    void Attack()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < distance) //ATTACK
        {
            //if near by attack
            isAttacked = true;
            playersHealth.isPlayerAttacked = true;
            if (Time.time > nextShotTime)
            {
                //shoot
                Instantiate(projectiele, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
                nextShotTime = Time.time + timebetweenShots;
            }

            anim.SetBool("IsAttacking", true);
            //playerAnim.SetBool("IsAttacking", true);

            if (Vector2.Distance(transform.position, player.transform.position) > distance * 0.5f)
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        }
        else
        {
            isAttacked = false;
            RandomeMove();
        }
    }
}
