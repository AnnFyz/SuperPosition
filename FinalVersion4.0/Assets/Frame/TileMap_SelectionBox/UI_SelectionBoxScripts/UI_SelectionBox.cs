using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_SelectionBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler
{
    public enum HandlerType
    {
        TopRight,
        Right,
        BottomRight,
        Bottom,
        BottomLeft,
        Left,
        TopLeft,
        Top
    }

    public HandlerType Type;
    public RectTransform Target;
    public Vector2 MinimumDimmensions = new Vector2(50, 50);
    public Vector2 MaximumDimmensions = new Vector2(800, 800);
    public float gridSize = 10f;

    public bool isPlayerInside;
    private GameObject player;
    private Vector3 PlayerPosition;
    //private RectTransform SelectionBox;
    private Vector3[] fourCornersArray;
    private Vector3 bottomLeftHandlerPos;
    private Vector3 topRightHandlerPos;
    private List<SelectedTile> selectedTileList;
    private GameObject[] TargetSelectionBoxs;
    //[SerializeField] RectTransform MaxRoomSize;
    private RectTransform draggedHandle;
    private Vector3 Y;
    private Vector3 maxBottomLeftPos;
    private Vector3 maxTopRightPos;
    private Vector3 RightHandlerPos;
    private Transform draggedObj;
    private Vector3 draggedObjPos;
    private bool isLocked;


    public void Start() {
        //= GetComponentInParent<CreateSpace>();
        //isLocked=false;
        //FindObjectOfType<EventSystem>().pixelDragThreshold = int.MaxValue;
        //MaxRoomSize = Target.parent.GetComponent<RectTransform>();
        //Target.SetParent(Target.parent);
        // MaxRoomSize = Target.parent.GetComponent<RectTransform>();
        // fourCornersArray = new Vector3[4];
        // MaxRoomSize.GetWorldCorners(fourCornersArray);
        // maxBottomLeftPos = fourCornersArray[0];
        // maxTopRightPos = fourCornersArray[2];
        // maxBottomLeftPos.x = maxWidthLeft;
        // maxBottomLeftPos.y = maxHeightBottom;
        // maxTopRightPos.x = maxWidthRight;
        // maxTopRightPos.y = maxHeighTop;
        // Debug.Log(maxWidthLeft);
        // Debug.Log(maxBottomLeftPos);
        // Target.GetComponent<RectTransform>().GetWorldCorners(fourCornersArray);
        // bottomLeftHandlerPos = fourCornersArray[0];
        // topRightHandlerPos = fourCornersArray[2];
        // bottomLeftHandlerPos.x = Mathf.Clamp(bottomLeftHandlerPos.x, maxBottomLeftPos.x, maxTopRightPos.x);
        // bottomLeftHandlerPos.y = Mathf.Clamp(bottomLeftHandlerPos.y, maxBottomLeftPos.y, maxTopRightPos.y);
        // topRightHandlerPos.x = Mathf.Clamp(topRightHandlerPos.x, maxBottomLeftPos.x, maxTopRightPos.x);
        // topRightHandlerPos.y = Mathf.Clamp(topRightHandlerPos.y, maxBottomLeftPos.y, maxTopRightPos.y);
        
        //Debug.Log("maxBottomLeftPos:" + maxBottomLeftPos); 
        //Debug.Log("bottomLeftHandlerPos:" + bottomLeftHandlerPos);
    }
    // private void Update() {
    //             player = GameObject.Find("Player");
    //     PlayerPosition = player.transform.position;
                    
    //     fourCornersArray = new Vector3[4];
    //     Target.GetComponent<RectTransform>().GetWorldCorners(fourCornersArray);
    //     bottomLeftHandlerPos = fourCornersArray[0];
    //     topRightHandlerPos = fourCornersArray[2];
    //     Debug.Log("topRightHandlerPos:" + topRightHandlerPos);
    //     Debug.Log("PlayerPos:" + PlayerPosition);

    //     // if(PlayerPosition.x > bottomLeftHandlerPos.x && PlayerPosition.x < topRightHandlerPos.x && PlayerPosition.y > bottomLeftHandlerPos.y && PlayerPosition.y < topRightHandlerPos.y)
    //     // {
    //     //     isPlayerInside = true;
    //     // }
    //     if(PlayerPosition.x < bottomLeftHandlerPos.x || PlayerPosition.y < bottomLeftHandlerPos.y || PlayerPosition.x > topRightHandlerPos.x || PlayerPosition.y > topRightHandlerPos.y )
    //     {
    //         isPlayerInside = false;
    //     }
    //     else{
    //         isPlayerInside = true;
    //     }
    //     if(isPlayerInside)
    //     {
    //         this.gameObject.SetActive(true);
    //         Debug.Log("player is inside");
    //     }
    //     else{
    //         this.gameObject.SetActive(false);
    //         Debug.Log("is empty");
    //     }
        
    // }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        player = GameObject.Find("Player");
        PlayerPosition = player.transform.position;
                    
        fourCornersArray = new Vector3[4];
        Target.GetComponent<RectTransform>().GetWorldCorners(fourCornersArray);
        bottomLeftHandlerPos = fourCornersArray[0];
        topRightHandlerPos = fourCornersArray[2];
        Debug.Log("topRightHandlerPos:" + topRightHandlerPos);
        Debug.Log("PlayerPos:" + PlayerPosition);

        // if(PlayerPosition.x > bottomLeftHandlerPos.x && PlayerPosition.x < topRightHandlerPos.x && PlayerPosition.y > bottomLeftHandlerPos.y && PlayerPosition.y < topRightHandlerPos.y)
        // {
        //     isPlayerInside = true;
        // }
        if(PlayerPosition.x < bottomLeftHandlerPos.x || PlayerPosition.y < bottomLeftHandlerPos.y || PlayerPosition.x > topRightHandlerPos.x || PlayerPosition.y > topRightHandlerPos.y )
        {
            isPlayerInside = false;
        }
        else{
            isPlayerInside = true;
        }
        if(isPlayerInside)
        {
            //this.gameObject.SetActive(true);
            Debug.Log("player is inside");
        }
        else{
            //this.gameObject.SetActive(false);
            Debug.Log("is empty");
        }
    }

    public float newWidth;
    public float newHeight;
    //public HandlerType Type;
    //public RectTransform Target;
    //public Vector2 MinimumDimmensions = new Vector2(50, 50);
    //public Vector2 MaximumDimmensions = new Vector2(800, 800);

    //[SerializeField] private Canvas canvas;
    [SerializeField] float maxWidthRight;
    [SerializeField] float maxWidthLeft;
    [SerializeField] float maxHeighTop;
    [SerializeField] float maxHeightBottom;

    //CreateSpace 
    //MaxRoomSize;

    public void OnDrag(PointerEventData pointerEventData)
    {
        PointerEventData ped = (PointerEventData)pointerEventData;
        Debug.Log("IS DRAGGING");
        //Target.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Target.rect.width + ped.delta.x);
        //Target.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Target.rect.height + ped.delta.y);
        RectTransform.Edge? horizontalEdge = null;
        RectTransform.Edge? verticalEdge = null;

        fourCornersArray = new Vector3[4];
        Target.GetComponent<RectTransform>().GetWorldCorners(fourCornersArray);
        bottomLeftHandlerPos = fourCornersArray[0];
        topRightHandlerPos = fourCornersArray[2];

        // maxBottomLeftPos.x = maxWidthLeft;
        // maxBottomLeftPos.y = maxHeightBottom;
        // maxTopRightPos.x = maxWidthRight;
        // maxTopRightPos.y = maxHeighTop;

        switch (Type)
        {
            case HandlerType.TopRight:
                horizontalEdge = RectTransform.Edge.Left;
                verticalEdge = RectTransform.Edge.Bottom;
                break;
            case HandlerType.Right:
                horizontalEdge = RectTransform.Edge.Left;
                break;
            case HandlerType.BottomRight:
                horizontalEdge = RectTransform.Edge.Left;
                verticalEdge = RectTransform.Edge.Top;
                break;
            case HandlerType.Bottom:
                verticalEdge = RectTransform.Edge.Top;
                break;
            case HandlerType.BottomLeft:
                horizontalEdge = RectTransform.Edge.Right;
                verticalEdge = RectTransform.Edge.Top;
                break;
            case HandlerType.Left:
                horizontalEdge = RectTransform.Edge.Right;
                break;
            case HandlerType.TopLeft:
                horizontalEdge = RectTransform.Edge.Right;
                verticalEdge = RectTransform.Edge.Bottom;
                break;
            case HandlerType.Top:
                verticalEdge = RectTransform.Edge.Bottom;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
 if (horizontalEdge != null)
        {
            if (horizontalEdge == RectTransform.Edge.Right && maxWidthLeft <= bottomLeftHandlerPos.x)
            {

                newWidth = Mathf.Clamp(Target.sizeDelta.x - ped.delta.x , MinimumDimmensions.x, MaximumDimmensions.x);
                float deltaPosX = -(newWidth - Target.sizeDelta.x) * Target.pivot.x;

                Target.sizeDelta = new Vector2(newWidth, Target.sizeDelta.y);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(deltaPosX, 0);
                //Debug.Log("Left");
            }

            if (horizontalEdge == RectTransform.Edge.Right && ped.delta.x >= 0f)
            {
                newWidth = Mathf.Clamp(Target.sizeDelta.x - ped.delta.x , MinimumDimmensions.x, MaximumDimmensions.x);
                float deltaPosX = -(newWidth - Target.sizeDelta.x) * Target.pivot.x;

                Target.sizeDelta = new Vector2(newWidth, Target.sizeDelta.y);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(deltaPosX, 0);
                //Debug.Log("LEFT");
                //Debug.Log(ped.delta.x);
            }


            if (horizontalEdge == RectTransform.Edge.Left && topRightHandlerPos.x <= maxWidthRight)
            {

                newWidth = Mathf.Clamp(Target.sizeDelta.x + ped.delta.x , MinimumDimmensions.x, MaximumDimmensions.x);
                float deltaPosX = (newWidth - Target.sizeDelta.x) * Target.pivot.x;

                Target.sizeDelta = new Vector2(newWidth, Target.sizeDelta.y);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(deltaPosX, 0);
                //Debug.Log("Right");
            }

            if (horizontalEdge == RectTransform.Edge.Left && ped.delta.x <= 0f)
            {

                newWidth = Mathf.Clamp(Target.sizeDelta.x + ped.delta.x , MinimumDimmensions.x, MaximumDimmensions.x);
                float deltaPosX = (newWidth - Target.sizeDelta.x) * Target.pivot.x;

                Target.sizeDelta = new Vector2(newWidth, Target.sizeDelta.y);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(deltaPosX, 0);
                //Debug.Log("RIGHT");
                //Debug.Log(ped.delta.x);
            }
        }
        if (verticalEdge != null)
        {
            if (verticalEdge == RectTransform.Edge.Top && maxHeightBottom <= bottomLeftHandlerPos.y)
            {
                newHeight = Mathf.Clamp(Target.sizeDelta.y - ped.delta.y , MinimumDimmensions.y, MaximumDimmensions.y);
                float deltaPosY = -(newHeight - Target.sizeDelta.y) * Target.pivot.y;

                Target.sizeDelta = new Vector2(Target.sizeDelta.x, newHeight);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(0, deltaPosY);
                //ebug.Log("Bottom");
            }

            if (verticalEdge == RectTransform.Edge.Top && ped.delta.y >= 0f)
            {
                newHeight = Mathf.Clamp(Target.sizeDelta.y - ped.delta.y , MinimumDimmensions.y, MaximumDimmensions.y);
                float deltaPosY = -(newHeight - Target.sizeDelta.y) * Target.pivot.y;

                Target.sizeDelta = new Vector2(Target.sizeDelta.x, newHeight);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(0, deltaPosY);
                //Debug.Log("BOTTOM");
            }
            if (verticalEdge == RectTransform.Edge.Bottom && topRightHandlerPos.y <= maxHeighTop)
            {
                newHeight = Mathf.Clamp(Target.sizeDelta.y + ped.delta.y , MinimumDimmensions.y, MaximumDimmensions.y);
                float deltaPosY = (newHeight - Target.sizeDelta.y) * Target.pivot.y;

                Target.sizeDelta = new Vector2(Target.sizeDelta.x, newHeight);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(0, deltaPosY);
                //Debug.Log("Top");
            }

            if (verticalEdge == RectTransform.Edge.Bottom && ped.delta.y <= 0f)
            {
                newHeight = Mathf.Clamp(Target.sizeDelta.y + ped.delta.y , MinimumDimmensions.y, MaximumDimmensions.y);
                float deltaPosY = (newHeight - Target.sizeDelta.y) * Target.pivot.y;

                Target.sizeDelta = new Vector2(Target.sizeDelta.x, newHeight);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(0, deltaPosY);
                //Debug.Log("TOP");
            }
        }
    }
        
    // }
    // public void OnDrag(PointerEventData pointerEventData){
    // {
    //     PointerEventData ped = (PointerEventData) pointerEventData;
    //     //Target.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Target.rect.width + ped.delta.x);
    //     //Target.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Target.rect.height + ped.delta.y);
    //     RectTransform.Edge? horizontalEdge = null;
    //     RectTransform.Edge? verticalEdge = null;

    //     fourCornersArray = new Vector3[4];
    //     Target.GetComponent<RectTransform>().GetWorldCorners(fourCornersArray);
    //     bottomLeftHandlerPos = fourCornersArray[0];
    //     topRightHandlerPos = fourCornersArray[2];
    //     if(bottomLeftHandlerPos.x < maxBottomLeftPos.x || bottomLeftHandlerPos.y < maxBottomLeftPos.y || topRightHandlerPos.x > maxTopRightPos.x || topRightHandlerPos.y > maxTopRightPos.y)
    //     { 
    //         Debug.Log("it's out of room");    
            //draggedObj = ped.pointerDrag.GetComponent<Transform>();
            //draggedObj.position =new Vector3(draggedObj.position.x, maxBottomLeftPos.y);
            //OnEndDrag(ped);

            
            //pointerEventData.pointerDrag = null;
            //ped.pointerDrag = null;
        //             if(bottomLeftHandlerPos.x < maxBottomLeftPos.x){
        //     bottomLeftHandlerPos.x = bottomLeftHandlerPos.x + 1f;
        // }
        // else if(bottomLeftHandlerPos.y < maxBottomLeftPos.y){
        //     bottomLeftHandlerPos.y =  bottomLeftHandlerPos.y  +1f;
        // }
        // else if(topRightHandlerPos.x > maxTopRightPos.x){
        //     topRightHandlerPos.x = topRightHandlerPos.x -1f;
        // }
        // else if(topRightHandlerPos.y > maxTopRightPos.y){
        //     topRightHandlerPos.y =  topRightHandlerPos.y -1f;
        // }
        //}
        
    

        // if(bottomLeftHandlerPos.x < maxBottomLeftPos.x){
        //     bottomLeftHandlerPos.x = maxBottomLeftPos.x + 1f;
        // }
        //     Vector3 dragVectorDirection = (ped.position - ped.pressPosition).normalized;
        //     GetDragDirection(dragVectorDirection);


        // if(bottomLeftHandlerPos.y < maxBottomLeftPos.y){
        //     if(draggedDirection == DraggedDirection.Up){
        //         Debug.Log("it's up");
        //     }
        //     else{
        //         ped.pointerDrag = null;
        //     }
            
        // }
        //     bottomLeftHandlerPos.y = maxBottomLeftPos.y +1f;
        // }
        // else if(topRightHandlerPos.x > maxTopRightPos.x){
        //     topRightHandlerPos.x = maxTopRightPos.x -1f;
        // }
        // else if(topRightHandlerPos.y > maxTopRightPos.y){
        //     topRightHandlerPos.y = maxTopRightPos.y -1f;
        // }
        

        // Target.GetComponent<RectTransform>().GetWorldCorners(fourCornersArray);

        // bottomLeftHandlerPos = fourCornersArray[0];
        // topRightHandlerPos = fourCornersArray[2];

        // bottomLeftHandlerPos.x = Mathf.Clamp(bottomLeftHandlerPos.x, maxBottomLeftPos.x, maxTopRightPos.x);
        // bottomLeftHandlerPos.y = Mathf.Clamp(bottomLeftHandlerPos.y, maxBottomLeftPos.y, maxTopRightPos.y);
        // topRightHandlerPos.x = Mathf.Clamp(topRightHandlerPos.x, maxTopRightPos.x, maxBottomLeftPos.x);
        // topRightHandlerPos.y = Mathf.Clamp(topRightHandlerPos.y , maxTopRightPos.y, maxBottomLeftPos.y);
        
    



        // if(isPlayerInside){  
        //         fourCornersArray = new Vector3[4];

        //         Target.GetComponent<RectTransform>().GetWorldCorners(fourCornersArray);
        //         bottomLeftHandlerPos = fourCornersArray[0];
        //         topRightHandlerPos = fourCornersArray[2];
        //         Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(bottomLeftHandlerPos+new Vector3(0.9f,0.9f),topRightHandlerPos-new Vector3(0.9f,0.9f));
                

        //         foreach(SelectedTile selectedTile in selectedTileList){
        //             selectedTile.SetSelectedVisible(true);
        //             }
        //         selectedTileList.Clear();
        //         foreach(Collider2D collider2D in collider2DArray){
        //             SelectedTile selectedTile = collider2D.GetComponent<SelectedTile>();
        //             if(selectedTile != null) {
        //                 selectedTile.SetSelectedVisible(false);
        //                 selectedTileList.Add(selectedTile);
        //             }
        //         }
            
        // }
        
        //topRightHandlerPos = transform.position;
        //Debug.Log(topRightHandlerPos);
        

        // fourCornersArray = new Vector3[4];
        // Target.GetWorldCorners(fourCornersArray);
        // bottomLeftHandlerPos = fourCornersArray[0];
        // topRightHandlerPos = fourCornersArray[2];
        // Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(bottomLeftHandlerPos+new Vector3(0.9f,0.9f),topRightHandlerPos-new Vector3(0.9f,0.9f));

        // if(mapGridObject.IsRoom()==false){
        // foreach(SelectedTile selectedTile in selectedTileList){
        //     selectedTile.SetSelectedVisible(false);
        //     }
        // selectedTileList.Clear();
        // foreach(Collider2D collider2D in collider2DArray){
        //     SelectedTile selectedTile = collider2D.GetComponent<SelectedTile>();
        //     if(selectedTile != null) {
        //         selectedTile.SetSelectedVisible(true);
        //         selectedTileList.Add(selectedTile);
        //         }
        //     }
        // Debug.Log(selectedTileList.Count);
        // }

        

        // Target.GetWorldCorners(fourCornersArray);
        // bottomLeftHandlerPos = fourCornersArray[0];
        // bottomLeftHandlerGridX = Mathf.RoundToInt(bottomLeftHandlerPos.x/gridSize);
        // bottomLeftHandlerGridY = Mathf.RoundToInt(bottomLeftHandlerPos.y/gridSize);
        // topRightHandlerPos = fourCornersArray[2];
        // topRightHandlerGridX = Mathf.RoundToInt(topRightHandlerPos.x/gridSize);
        // topRightHandlerGridY = Mathf.RoundToInt(topRightHandlerPos.y/gridSize);
        // Debug.Log(topRightHandlerGridX + "+" + topRightHandlerGridY);
        // Debug.Log(bottomLeftHandlerGridX + "+" + bottomLeftHandlerGridY);

        // for(int i = bottomLeftHandlerGridX; i < topRightHandlerGridX; i++){
        //     for(int j = bottomLeftHandlerGridY; j < topRightHandlerGridY; j++){
        //         MapGridObject.Type gridType = map.RevealGridPosition(new Vector3(i,j));
        //     }
        // }
        
        //Target.position = new Vector2(Mathf.RoundToInt(transform.position.x/gridSize)*gridSize,Mathf.RoundToInt(transform.position.y/gridSize)*gridSize);
        // switch (Type)
        // {
        //     case HandlerType.TopRight:
        //         horizontalEdge = RectTransform.Edge.Left;
        //         verticalEdge = RectTransform.Edge.Bottom;
        //         break;
        //     case HandlerType.Right:
        //         horizontalEdge = RectTransform.Edge.Left;
        //         break;
        //     case HandlerType.BottomRight:
        //         horizontalEdge = RectTransform.Edge.Left;
        //         verticalEdge = RectTransform.Edge.Top;
        //         break;
        //     case HandlerType.Bottom:
        //         verticalEdge = RectTransform.Edge.Top;
        //         break;
        //     case HandlerType.BottomLeft:
        //         horizontalEdge = RectTransform.Edge.Right;
        //         verticalEdge = RectTransform.Edge.Top;
        //         break;
        //     case HandlerType.Left:
        //         horizontalEdge = RectTransform.Edge.Right;
        //         break;
        //     case HandlerType.TopLeft:
        //         horizontalEdge = RectTransform.Edge.Right;
        //         verticalEdge = RectTransform.Edge.Bottom;
        //         break;
        //     case HandlerType.Top:
        //         verticalEdge = RectTransform.Edge.Bottom;
        //         break;
        //     default:
        //         throw new ArgumentOutOfRangeException();
        // }
        // if (horizontalEdge != null)
        // {
        //     if (horizontalEdge == RectTransform.Edge.Right)
        //         Target.SetInsetAndSizeFromParentEdge((RectTransform.Edge)horizontalEdge, 
        //             Screen.width - Target.position.x - Target.pivot.x * Target.rect.width, 
        //             Mathf.Clamp(Target.rect.width - ped.delta.x, MinimumDimmensions.x, MaximumDimmensions.x));
        //     else 
        //         Target.SetInsetAndSizeFromParentEdge((RectTransform.Edge)horizontalEdge, 
        //             Target.position.x - Target.pivot.x * Target.rect.width, 
        //             Mathf.Clamp(Target.rect.width + ped.delta.x, MinimumDimmensions.x, MaximumDimmensions.x));
        // }
        // if (verticalEdge != null)
        // {
        //     if (verticalEdge == RectTransform.Edge.Top)
        //         Target.SetInsetAndSizeFromParentEdge((RectTransform.Edge)verticalEdge, 
        //             Screen.height - Target.position.y - Target.pivot.y * Target.rect.height, 
        //             Mathf.Clamp(Target.rect.height - ped.delta.y, MinimumDimmensions.y, MaximumDimmensions.y));
        //     else 
        //         Target.SetInsetAndSizeFromParentEdge((RectTransform.Edge)verticalEdge, 
        //             Target.position.y - Target.pivot.y * Target.rect.height, 
        //             Mathf.Clamp(Target.rect.height + ped.delta.y, MinimumDimmensions.y, MaximumDimmensions.y));
        // }

        
    //     if (horizontalEdge != null)
    //     {
    //         if (horizontalEdge == RectTransform.Edge.Right)
    //         {
    //             float newWidth = Mathf.Clamp(Mathf.RoundToInt((Target.sizeDelta.x - ped.delta.x)/gridSize)*gridSize, MinimumDimmensions.x, MaximumDimmensions.x);
    //             float deltaPosX = -(newWidth - Target.sizeDelta.x) * Target.pivot.x;

    //             Target.sizeDelta = new Vector2(newWidth, Target.sizeDelta.y);
    //             Target.anchoredPosition = Target.anchoredPosition + new Vector2(deltaPosX, 0);
    //         }
    //         else
    //         {
    //             float newWidth = Mathf.Clamp(Mathf.RoundToInt((Target.sizeDelta.x + ped.delta.x)/gridSize)*gridSize, MinimumDimmensions.x, MaximumDimmensions.x);
    //             float deltaPosX = (newWidth - Target.sizeDelta.x) * Target.pivot.x;

    //             Target.sizeDelta = new Vector2(newWidth,Target.sizeDelta.y);
    //             Target.anchoredPosition = Target.anchoredPosition + new Vector2(deltaPosX, 0);
    //         }
    //     }
    //     if (verticalEdge != null)
    //     {
    //         if (verticalEdge == RectTransform.Edge.Top)
    //         {
    //             float newHeight = Mathf.Clamp(Mathf.RoundToInt((Target.sizeDelta.y - ped.delta.y)/gridSize)*gridSize, MinimumDimmensions.y, MaximumDimmensions.y);
    //             float deltaPosY = -(newHeight - Target.sizeDelta.y) * Target.pivot.y;

    //             Target.sizeDelta = new Vector2(Target.sizeDelta.x,newHeight);
    //             Target.anchoredPosition = Target.anchoredPosition + new Vector2(0, deltaPosY);
    //         }
    //         else
    //         {
    //             float newHeight = Mathf.Clamp(Mathf.RoundToInt((Target.sizeDelta.y + ped.delta.y)/gridSize)*gridSize, MinimumDimmensions.y, MaximumDimmensions.y);
    //             float deltaPosY = (newHeight - Target.sizeDelta.y) * Target.pivot.y;

    //             Target.sizeDelta = new Vector2(Target.sizeDelta.x, newHeight);
    //             Target.anchoredPosition = Target.anchoredPosition + new Vector2(0, deltaPosY);
    //         }
    //     }
    // }
    
    // }
    public void OnPointerExit(PointerEventData pointerEventData){

    }

    // public void OnDeselect(PointerEventData pointerEventData){
    // }
    public void OnEndDrag(PointerEventData pointerEventData)
    {
    // Debug.Log("Press position + " + eventData.pressPosition);
    // Debug.Log("End position + " + eventData.position);
    // Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
    // Debug.Log("norm + " + dragVectorDirection);
    // GetDragDirection(dragVectorDirection);
    //pointerEventData.
    }    

}
