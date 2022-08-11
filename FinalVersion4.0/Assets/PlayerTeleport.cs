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
    public Animator anim;
    public Animator anim1;
    public Animator anim2;

    //[SerializeField] private AudioSource winSoundEffect;
    //[SerializeField] private AudioSource wrongSoundEffect;

    void Start()
    {
       
        isPinkTeleporterOpen = false;
       
        isGreenTeleporterOpen =false;
        isOrangeTeleporterOpen =false;
        WarningWindow.SetActive(false);


        //anim.SetBool("open", false);
        //anim3.SetBool("open", false);
        //anim2.SetBool("open", false);

        
    }
    void Update()
    {
        if (isGreenTeleporterOpen == true)
        {
            
           Instantiate(GopenParticles);
            //anim.SetBool("open", true);
            

        }
         if (isPinkTeleporterOpen == true)
        {
            
           Instantiate(PopenParticles);
            //anim1.SetBool("open", true);
            

        }
         if (isOrangeTeleporterOpen == true)
        {
            
           Instantiate(OopenParticles);
            //anim2.SetBool("open", true);
            

        }





        if (Input.GetKeyDown(KeyCode.E))
        {

            if (PinkTeleporter != null && isPinkTeleporterOpen)
                    {
                         anim1.SetBool("open", true);
                        transform.position = PinkTeleporter.GetComponent<Teleporter>().GetDestination().position;
                        teleportet = true;
                    }
                    if(BlueTeleporter != null )
                    {
                         
                         transform.position = BlueTeleporter.GetComponent<Teleporter>().GetDestination().position;
                        teleportet = true;
                    }
                    if(GreenTeleporter != null && isGreenTeleporterOpen)
                    {
                         anim.SetBool("open", true);
                        transform.position = GreenTeleporter.GetComponent<Teleporter>().GetDestination().position;
                        teleportet = true;
                    }
                    if(OrangeTeleporter != null && isOrangeTeleporterOpen)
                    {

                        anim2.SetBool("open", true);
                        transform.position = OrangeTeleporter.GetComponent<Teleporter>().GetDestination().position;
                        teleportet = true;
                    }
                else
                 {

                     if (inrange)
                    WarningWindow.SetActive(true);
                //wrongSoundEffect.Play();

                }





        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {

        


        if (other.CompareTag("PinkTeleporter"))
        {
            inrange = true;
            Debug.Log("teleporter detektet");
           PinkTeleporter = other.gameObject; 
        }
        if(other.CompareTag("BlueTeleporter"))
        {
            inrange = true;
            Debug.Log("teleporter detektet");
           BlueTeleporter = other.gameObject; 
        }
        if(other.CompareTag("GreenTeleporter"))
        {
            inrange = true;
            Debug.Log("teleporter detektet");
           GreenTeleporter = other.gameObject; 
        }
        if(other.CompareTag("OrangeTeleporter"))
        {
            inrange = true;
            Debug.Log("teleporter detektet");
           OrangeTeleporter = other.gameObject; 
        }
    }
     

   void OnTriggerExit2D(Collider2D other)
    {
        WarningWindow.SetActive(false);

        if (other.CompareTag("PinkTeleporter"))
        {
            inrange = false;
            if (other.gameObject == PinkTeleporter)
          {
              Debug.Log("player exits the teleporter");
              PinkTeleporter = null;
          }   
        }
        if(other.CompareTag("BlueTeleporter"))
        {
         if(other.gameObject == BlueTeleporter)
          {
                inrange = false;
                Debug.Log("player exits the teleporter");
              BlueTeleporter = null;
          }   
        }
        if(other.CompareTag("OrangeTeleporter"))
        {
         if(other.gameObject == OrangeTeleporter)
          {
                inrange = false;
                Debug.Log("player exits the teleporter");
              OrangeTeleporter = null;
          }   
        }
        if(other.CompareTag("GreenTeleporter"))
        {
         if(other.gameObject == GreenTeleporter)
          {
                inrange = false;
                Debug.Log("player exits the teleporter");
              GreenTeleporter = null;
          }   
        }
    }
}
