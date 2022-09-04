using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRoom : MonoBehaviour
{
    public bool IsRoomUnlocked = false;
    public GameObject draggableFrame;
    public CreateSpace spaceInRoom;
    private void Awake()
    {
       
    }
    void Start()
    {
        draggableFrame = transform.Find("Frame").gameObject;
        spaceInRoom = draggableFrame.GetComponent<CreateSpace>();
        draggableFrame.SetActive(false);
        //spaceInRoom.CleanRoom();
        if (IsRoomUnlocked)
        {
            draggableFrame.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRoomUnlocked)
        {
            draggableFrame.SetActive(true);
        }
        else
        {
            spaceInRoom.CleanRoom();
            draggableFrame.SetActive(false);
        }

    }
}
