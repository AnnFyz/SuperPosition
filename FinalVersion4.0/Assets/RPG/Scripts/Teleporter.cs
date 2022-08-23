using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    public GameObject windowHasKey;
    public GameObject player;
    public bool playerDetected;
    public Transform GetDestination()
    {
        return destination;
    }

    private void Start()
    {
       
        ToggleHasKey(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ToggleHasKey(bool show)
    {
        windowHasKey.SetActive(show);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDetected = true;
            windowHasKey.SetActive(playerDetected);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDetected = false;
            windowHasKey.SetActive(playerDetected);
        }
    }

    private void Update()
    {
        if(destination != null &&playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = new Vector3 (destination.position.x, destination.position.y);

        }
    }
}
