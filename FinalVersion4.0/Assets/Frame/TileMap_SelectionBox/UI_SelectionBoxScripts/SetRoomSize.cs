using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRoomSize : MonoBehaviour
{
    [SerializeField] private DrawTileMap drawTileMap;
    //[SerializeField] private Transform pfGridVisual;

    private List<SelectedTile> selectedTileList;
    private RectTransform SelectionBox;
    private Vector3[] fourCornersArray;
    private Vector3 bottomLeftHandlerPos;
    private Vector3 topRightHandlerPos;
    private int topRightHandlerGridX;
    private int topRightHandlerGridY;
    private float gridSize = 1f;

    private int bottomLeftHandlerGridX;
    private int bottomLeftHandlerGridY;
        private Map map;
        private bool isGameActive;

    public float selectionBoxWidth;
    public float selectionBoxHeight;
    public Vector3 centerSelectionBox;
    void Start()
    {
        isGameActive = true;
        selectedTileList = new List<SelectedTile>();
         this.SelectionBox = GetComponent<RectTransform>();
         

            fourCornersArray = new Vector3[4];


            SelectionBox.GetWorldCorners(fourCornersArray);
            bottomLeftHandlerPos = fourCornersArray[0];
            bottomLeftHandlerGridX = Mathf.FloorToInt(bottomLeftHandlerPos.x/gridSize);
            bottomLeftHandlerGridY = Mathf.FloorToInt(bottomLeftHandlerPos.y/gridSize);
            topRightHandlerPos = fourCornersArray[2];
            topRightHandlerGridX = Mathf.FloorToInt(topRightHandlerPos.x/gridSize);
            topRightHandlerGridY = Mathf.FloorToInt(topRightHandlerPos.y/gridSize);
            Debug.Log(topRightHandlerGridX + "+" + topRightHandlerGridY);
            Debug.Log(bottomLeftHandlerGridX + "+" + bottomLeftHandlerGridY);

            // for(int i = bottomLeftHandlerGridX; i <= topRightHandlerGridX; i++){
            //     for(int j = bottomLeftHandlerGridY; j <= topRightHandlerGridY; j++){
            //         MapGridObject.Type gridType = map.RevealGridPosition(new Vector3(i,j));
            //         //MapGridObject mapGridObject = grid.GetGridObject(i,j);
            //         //mapGridObject.SetGridType(MapGridObject.Type.Room);
            //     }
            // }

            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(bottomLeftHandlerPos+new Vector3(.5f, .5f),topRightHandlerPos-new Vector3(.5f, .5f));
            

            foreach(SelectedTile selectedTile in selectedTileList){
                selectedTile.SetSelectedVisible(true);
                }
            selectedTileList.Clear();
            foreach(Collider2D collider2D in collider2DArray){
                SelectedTile selectedTile = collider2D.GetComponent<SelectedTile>();
                if(selectedTile != null) {
                    selectedTile.SetSelectedVisible(false);
                    selectedTileList.Add(selectedTile);
                    }
            }

        fourCornersArray = new Vector3[4];

        SelectionBox.GetWorldCorners(fourCornersArray);
        bottomLeftHandlerPos = fourCornersArray[0];
        topRightHandlerPos = fourCornersArray[2];

        centerSelectionBox = fourCornersArray[0] + (0.5f * (fourCornersArray[2] - fourCornersArray[2]));
        selectionBoxWidth = fourCornersArray[2].x - fourCornersArray[0].x;
        selectionBoxHeight = fourCornersArray[2].y - fourCornersArray[0].y;

    }

 private void Update() {

        if(Input.GetMouseButton(0)){

            if(isGameActive){  

                fourCornersArray = new Vector3[4];

                SelectionBox.GetWorldCorners(fourCornersArray);
                bottomLeftHandlerPos = fourCornersArray[0];
                topRightHandlerPos = fourCornersArray[2];

                centerSelectionBox = fourCornersArray[0] + (0.5f * (fourCornersArray[2] - fourCornersArray[2]));
                selectionBoxWidth = fourCornersArray[2].x - fourCornersArray[0].x;
                selectionBoxHeight = fourCornersArray[2].y - fourCornersArray[0].y;


                Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(bottomLeftHandlerPos+new Vector3(.5f, .5f),topRightHandlerPos-new Vector3(.5f, .5f));
                
                foreach(SelectedTile selectedTile in selectedTileList){
                selectedTile.SetSelectedVisible(true);
                }
                selectedTileList.Clear();
                foreach(Collider2D collider2D in collider2DArray){
                SelectedTile selectedTile = collider2D.GetComponent<SelectedTile>();
                if(selectedTile != null) {
                    selectedTile.SetSelectedVisible(false);
                    selectedTileList.Add(selectedTile);
                    }
                }
            }
        }
 }

}
