using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTeleport : MonoBehaviour
{
    public GameObject GopenParticles;
    public GameObject PopenParticles;
    public GameObject OopenParticles;


    public GameObject WarningWindow;

    public GameObject PinkTeleporter;
    public GameObject BlueTeleporter;
    public GameObject GreenTeleporter;
    public GameObject OrangeTeleporter;
    public bool teleportet;
    public bool isPinkTeleporterOpen;

    public bool inrange = false;


    public bool isGreenTeleporterOpen;
    public bool isOrangeTeleporterOpen;

    void Start()
    {

        isPinkTeleporterOpen = false;

        isGreenTeleporterOpen = false;
        isOrangeTeleporterOpen = false;
        WarningWindow.SetActive(false);

    }
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (PinkTeleporter != null && isPinkTeleporterOpen)
            {
               
                transform.position = PinkTeleporter.GetComponent<Teleporter>().GetDestination().position;
                teleportet = true;
            }
            if (BlueTeleporter != null)
            {

                transform.position = BlueTeleporter.GetComponent<Teleporter>().GetDestination().position;
                teleportet = true;
            }
            if (GreenTeleporter != null && isGreenTeleporterOpen)
            {
               
                transform.position = GreenTeleporter.GetComponent<Teleporter>().GetDestination().position;
                teleportet = true;
            }
            if (OrangeTeleporter != null && isOrangeTeleporterOpen)
            {

                transform.position = OrangeTeleporter.GetComponent<Teleporter>().GetDestination().position;
                teleportet = true;
            }
            else
            {

                if (inrange)
                WarningWindow.SetActive(true);
  
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("PinkTeleporter") && other != null)
        {
            inrange = true;
            Debug.Log("teleporter detektet");
            PinkTeleporter = other.gameObject;
        }
        if (other.CompareTag("BlueTeleporter") && other != null)
        {
            inrange = true;
            Debug.Log("teleporter detektet");
            BlueTeleporter = other.gameObject;
        }
        if (other.CompareTag("GreenTeleporter") && other != null)
        {
            inrange = true;
            Debug.Log("teleporter detektet");
            GreenTeleporter = other.gameObject;
        }
        if (other.CompareTag("OrangeTeleporter") && other != null)
        {
            inrange = true;
            Debug.Log("teleporter detektet");
            OrangeTeleporter = other.gameObject;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        WarningWindow.SetActive(false);

        if (other.CompareTag("PinkTeleporter") && other != null)
        {
            inrange = false;
            if (other.gameObject == PinkTeleporter)
            {
                Debug.Log("player exits the teleporter");
                PinkTeleporter = null;
            }
        }
        if (other.CompareTag("BlueTeleporter") && other != null)
        {
            if (other.gameObject == BlueTeleporter)
            {
                inrange = false;
                Debug.Log("player exits the teleporter");
                BlueTeleporter = null;
            }
        }
        if (other.CompareTag("OrangeTeleporter") && other != null)
        {
            if (other.gameObject == OrangeTeleporter)
            {
                inrange = false;
                Debug.Log("player exits the teleporter");
                OrangeTeleporter = null;
            }
        }
        if (other.CompareTag("GreenTeleporter") && other != null)
        {
            if (other.gameObject == GreenTeleporter)
            {
                inrange = false;
                Debug.Log("player exits the teleporter");
                GreenTeleporter = null;
            }
        }
    }
}
