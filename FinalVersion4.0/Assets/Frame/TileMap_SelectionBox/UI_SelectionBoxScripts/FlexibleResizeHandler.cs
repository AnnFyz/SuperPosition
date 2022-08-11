using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

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

[RequireComponent(typeof(EventTrigger))]
public class FlexibleResizeHandler : MonoBehaviour
{

    public float newWidth;
    public float newHeight;
    public HandlerType Type;
    public RectTransform Target;
    public Vector2 MinimumDimmensions = new Vector2(50, 50);
    public Vector2 MaximumDimmensions = new Vector2(800, 800);

    [SerializeField] private Canvas canvas;
    [SerializeField] float maxWidthRight;
    [SerializeField] float maxWidthLeft;

    [SerializeField] float maxHeighTop;
    [SerializeField] float maxHeightBottom;

    private EventTrigger _eventTrigger;

    CreateSpace maxSize;
    //MaxRoomSize;
    void Start()
    {
        _eventTrigger = GetComponent<EventTrigger>();
        _eventTrigger.AddEventTrigger(OnDrag, EventTriggerType.Drag);
        maxSize = GetComponentInParent<CreateSpace>();
    }
    void OnDrag(BaseEventData data)
    {
        PointerEventData ped = (PointerEventData)data;
        //Target.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Target.rect.width + ped.delta.x);
        //Target.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Target.rect.height + ped.delta.y);
        RectTransform.Edge? horizontalEdge = null;
        RectTransform.Edge? verticalEdge = null;

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
            if (horizontalEdge == RectTransform.Edge.Right && maxWidthLeft <= maxSize.bottomLeftHandlerPos.x)
            {

                newWidth = Mathf.Clamp(Target.sizeDelta.x - ped.delta.x / canvas.scaleFactor, MinimumDimmensions.x, MaximumDimmensions.x);
                float deltaPosX = -(newWidth - Target.sizeDelta.x) * Target.pivot.x;

                Target.sizeDelta = new Vector2(newWidth, Target.sizeDelta.y);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(deltaPosX, 0);
                Debug.Log("Left");
            }

            if (horizontalEdge == RectTransform.Edge.Right && ped.delta.x >= 0f)
            {
                newWidth = Mathf.Clamp(Target.sizeDelta.x - ped.delta.x / canvas.scaleFactor, MinimumDimmensions.x, MaximumDimmensions.x);
                float deltaPosX = -(newWidth - Target.sizeDelta.x) * Target.pivot.x;

                Target.sizeDelta = new Vector2(newWidth, Target.sizeDelta.y);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(deltaPosX, 0);
                Debug.Log("LEFT");
                Debug.Log(ped.delta.x);
            }


            if (horizontalEdge == RectTransform.Edge.Left && maxSize.topRightHandlerPos.x <= maxWidthRight)
            {

                newWidth = Mathf.Clamp(Target.sizeDelta.x + ped.delta.x / canvas.scaleFactor, MinimumDimmensions.x, MaximumDimmensions.x);
                float deltaPosX = (newWidth - Target.sizeDelta.x) * Target.pivot.x;

                Target.sizeDelta = new Vector2(newWidth, Target.sizeDelta.y);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(deltaPosX, 0);
                Debug.Log("Right");
            }

            if (horizontalEdge == RectTransform.Edge.Left && ped.delta.x <= 0f)
            {

                newWidth = Mathf.Clamp(Target.sizeDelta.x + ped.delta.x / canvas.scaleFactor, MinimumDimmensions.x, MaximumDimmensions.x);
                float deltaPosX = (newWidth - Target.sizeDelta.x) * Target.pivot.x;

                Target.sizeDelta = new Vector2(newWidth, Target.sizeDelta.y);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(deltaPosX, 0);
                Debug.Log("RIGHT");
                Debug.Log(ped.delta.x);
            }
        }
        if (verticalEdge != null)
        {
            if (verticalEdge == RectTransform.Edge.Top && maxHeightBottom <= maxSize.bottomLeftHandlerPos.y)
            {
                newHeight = Mathf.Clamp(Target.sizeDelta.y - ped.delta.y / canvas.scaleFactor, MinimumDimmensions.y, MaximumDimmensions.y);
                float deltaPosY = -(newHeight - Target.sizeDelta.y) * Target.pivot.y;

                Target.sizeDelta = new Vector2(Target.sizeDelta.x, newHeight);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(0, deltaPosY);
                Debug.Log("Bottom");
            }

            if (verticalEdge == RectTransform.Edge.Top && ped.delta.y >= 0f)
            {
                newHeight = Mathf.Clamp(Target.sizeDelta.y - ped.delta.y / canvas.scaleFactor, MinimumDimmensions.y, MaximumDimmensions.y);
                float deltaPosY = -(newHeight - Target.sizeDelta.y) * Target.pivot.y;

                Target.sizeDelta = new Vector2(Target.sizeDelta.x, newHeight);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(0, deltaPosY);
                Debug.Log("BOTTOM");
            }
            if (verticalEdge == RectTransform.Edge.Bottom && maxSize.topRightHandlerPos.y <= maxHeighTop)
            {
                newHeight = Mathf.Clamp(Target.sizeDelta.y + ped.delta.y / canvas.scaleFactor, MinimumDimmensions.y, MaximumDimmensions.y);
                float deltaPosY = (newHeight - Target.sizeDelta.y) * Target.pivot.y;

                Target.sizeDelta = new Vector2(Target.sizeDelta.x, newHeight);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(0, deltaPosY);
                Debug.Log("Top");
            }

            if (verticalEdge == RectTransform.Edge.Bottom && ped.delta.y <= 0f)
            {
                newHeight = Mathf.Clamp(Target.sizeDelta.y + ped.delta.y / canvas.scaleFactor, MinimumDimmensions.y, MaximumDimmensions.y);
                float deltaPosY = (newHeight - Target.sizeDelta.y) * Target.pivot.y;

                Target.sizeDelta = new Vector2(Target.sizeDelta.x, newHeight);
                Target.anchoredPosition = Target.anchoredPosition + new Vector2(0, deltaPosY);
                Debug.Log("TOP");
            }
        }
    }
    //    if (horizontalEdge != null)
    //    {
    //        if (horizontalEdge == RectTransform.Edge.Right)
    //        {
    //            float newWidth = Mathf.Clamp(Target.sizeDelta.x - ped.delta.x, MinimumDimmensions.x, MaximumDimmensions.x);
    //            float deltaPosX = -(newWidth - Target.sizeDelta.x) * Target.pivot.x;

    //            Target.sizeDelta = new Vector2(Mathf.RoundToInt(newWidth / cellSize) * cellSize, Mathf.RoundToInt(Target.sizeDelta.y / cellSize) * cellSize);
    //            Target.anchoredPosition = Target.anchoredPosition + new Vector2(Mathf.RoundToInt(deltaPosX/ cellSize) * cellSize, 0);
    //        }
    //        else
    //        {
    //            float newWidth = Mathf.Clamp(Target.sizeDelta.x + ped.delta.x, MinimumDimmensions.x, MaximumDimmensions.x);
    //            float deltaPosX = (newWidth - Target.sizeDelta.x) * Target.pivot.x;

    //            Target.sizeDelta = new Vector2(Mathf.RoundToInt(newWidth / cellSize) * cellSize, Mathf.RoundToInt(Target.sizeDelta.y / cellSize) * cellSize);
    //            Target.anchoredPosition = Target.anchoredPosition + new Vector2(Mathf.RoundToInt(deltaPosX / cellSize) * cellSize, 0);
    //        }
    //    }
    //    if (verticalEdge != null)
    //    {
    //        if (verticalEdge == RectTransform.Edge.Top)
    //        {
    //            float newHeight = Mathf.Clamp(Target.sizeDelta.y - ped.delta.y, MinimumDimmensions.y, MaximumDimmensions.y);
    //            float deltaPosY = -(newHeight - Target.sizeDelta.y) * Target.pivot.y;

    //            Target.sizeDelta = new Vector2(Mathf.RoundToInt(Target.sizeDelta.x / cellSize) * cellSize, Mathf.RoundToInt(newHeight / cellSize) * cellSize);
    //            Target.anchoredPosition = Target.anchoredPosition + new Vector2(0, Mathf.RoundToInt(deltaPosY / cellSize) * cellSize);
    //        }
    //        else
    //        {
    //            float newHeight = Mathf.Clamp(Target.sizeDelta.y + ped.delta.y, MinimumDimmensions.y, MaximumDimmensions.y);
    //            float deltaPosY = (newHeight - Target.sizeDelta.y) * Target.pivot.y;

    //            Target.sizeDelta = new Vector2(Mathf.RoundToInt(Target.sizeDelta.x / cellSize) * cellSize, Mathf.RoundToInt(newHeight / cellSize) * cellSize);
    //            Target.anchoredPosition = Target.anchoredPosition + new Vector2(0, Mathf.RoundToInt(deltaPosY / cellSize) * cellSize);
    //        }
    //    }
    //}


}