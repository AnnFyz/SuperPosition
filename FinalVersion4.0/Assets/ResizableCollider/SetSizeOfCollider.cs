using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSizeOfCollider : MonoBehaviour
{
    [SerializeField] string roomsTag;
    [SerializeField] float xSize;
    [SerializeField] float ySize;
    [SerializeField] Vector3 position;
    [SerializeField] SetRoomSize frameObj;
    BoxCollider2D collider;
    void Start()
    {
        frameObj = GameObject.FindGameObjectWithTag(roomsTag).GetComponentInChildren<SetRoomSize>();
        xSize = transform.localScale.x;
        ySize = transform.localScale.y;
        position = transform.position;
        collider = GetComponent<BoxCollider2D>();
        collider.size = new Vector2(1f, 1f);
        SetColliderSizeAndPosition();
    }

    // Update is called once per frame
    void Update()
    {
        SetColliderSizeAndPosition();
    }

    void SetColliderSizeAndPosition()
    {
       
        xSize = frameObj.selectionBoxWidth;
        ySize = frameObj.selectionBoxHeight;
        position = frameObj.centerSelectionBox;
        transform.localScale = new Vector3(xSize, ySize);
        transform.position = position + transform.localScale*0.5f;
    }

}
