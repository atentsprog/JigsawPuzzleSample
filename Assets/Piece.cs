using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Piece : MonoBehaviour, IDragHandler
    , IBeginDragHandler, IEndDragHandler
{
    public Vector2 offsetDrag;
    Vector3 dragStartPosition;
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPosition = transform.position;
        Vector2 pos = new Vector2(dragStartPosition.x
            , dragStartPosition.y);

        offsetDrag = pos - eventData.position;

        GetComponent<Image>().raycastTarget = false;
        transform.SetAsLastSibling();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + offsetDrag;
    }

    internal void ResetPosition()
    {
        transform.position = dragStartPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
    }
}
