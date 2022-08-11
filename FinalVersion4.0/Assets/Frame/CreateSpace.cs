using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateSpace : MonoBehaviour
{
    //[SerializeField] private PrefabVisual prefabVisual;
    private FlexibleResizeHandler UIFrameHandler;
    private float timer;
    private bool isGameActive;
    private Vector3[] fourCornersArray;

    public Vector3 topRightHandlerPos;
    public Vector3 bottomLeftHandlerPos;
    private int topRightHandlerGridX;
    private int topRightHandlerGridY;
    private int bottomLeftHandlerGridX;
    private int bottomLeftHandlerGridY;
    public static float gridSize = 0.5f;
    private List<SelectedTile> selectedTileList;
    private RectTransform SelectionBox;
    UnlockRoom unlockRoom;

    public float selectionBoxWidth;
    public float selectionBoxHeight;
    public Vector3 centerSelectionBox;
    private void Start()
    {
        isGameActive = true;
        unlockRoom = GetComponentInParent<UnlockRoom>();

        selectedTileList = new List<SelectedTile>();
        SelectionBox = GetComponent<RectTransform>();
        fourCornersArray = new Vector3[4];
        SelectionBox.GetWorldCorners(fourCornersArray);
        bottomLeftHandlerPos = fourCornersArray[0];
        bottomLeftHandlerGridX = Mathf.FloorToInt(bottomLeftHandlerPos.x / gridSize);
        bottomLeftHandlerGridY = Mathf.FloorToInt(bottomLeftHandlerPos.y / gridSize);
        topRightHandlerPos = fourCornersArray[2];
        topRightHandlerGridX = Mathf.FloorToInt(topRightHandlerPos.x / gridSize);
        topRightHandlerGridY = Mathf.FloorToInt(topRightHandlerPos.y / gridSize);
        //Debug.Log(topRightHandlerGridX + "+" + topRightHandlerGridY);
        //Debug.Log(bottomLeftHandlerGridX + "+" + bottomLeftHandlerGridY);

        //for (int i = bottomLeftHandlerGridX; i <= topRightHandlerGridX; i++)
        //{
        //    for (int j = bottomLeftHandlerGridY; j <= topRightHandlerGridY; j++)
        //    {
        //        MapGridObject.Type gridType = map.RevealGridPosition(new Vector3(i, j));
        //    }
        //}
        CreateRoom();
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        CreateRoom();
    //    }

    //}

    private void Update()
    {
        if(unlockRoom == null)
        {
            return;
        }
        if (unlockRoom.IsRoomUnlocked)
        { 
            CreateRoom();
        }
        //else
        //{
        //    foreach (SelectedTile selectedTile in selectedTileList)
        //    {
        //        selectedTile.SetSelectedVisible(true);
        //    }
        //    selectedTileList.Clear();
        //}

    }

    //private void HandleTimer() {
    //if (isGameActive) {
    //    timer += Time.deltaTime;
    //    timerText.text = Mathf.FloorToInt(timer).ToString();
    //}
    //}

    void CreateRoom()
    {
        if (isGameActive)
        {
            SelectionBox = GetComponent<RectTransform>();
            SelectionBox.gameObject.SetActive(true);
            fourCornersArray = new Vector3[4];
            SelectionBox.GetWorldCorners(fourCornersArray);
            centerSelectionBox = fourCornersArray[0] + (0.5f * (fourCornersArray[2] - fourCornersArray[2]));
            selectionBoxWidth = fourCornersArray[2].x - fourCornersArray[0].x;
            selectionBoxHeight = fourCornersArray[2].y - fourCornersArray[0].y;
            bottomLeftHandlerPos = fourCornersArray[0];
            topRightHandlerPos = fourCornersArray[2];
            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(bottomLeftHandlerPos + new Vector3(0.25f, 0.25f), topRightHandlerPos - new Vector3(0.25f, 0.25f));



            foreach (SelectedTile selectedTile in selectedTileList)
            {
                selectedTile.SetSelectedVisible(true);
            }
            selectedTileList.Clear();


            foreach (Collider2D collider2D in collider2DArray)
            {
                SelectedTile selectedTile = collider2D.GetComponent<SelectedTile>();


                if (selectedTile != null)
                {
                    selectedTile.SetSelectedVisible(false);
                    selectedTileList.Add(selectedTile);
                }
            }
        }

    }

    public void CleanRoom()
    {
        if (selectedTileList == null)
            return;
        foreach (SelectedTile selectedTile in selectedTileList)
        {
           
            selectedTile.SetSelectedVisible(true);
        }
        selectedTileList.Clear();
    }
}
