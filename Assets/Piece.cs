using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Piece : MonoBehaviour, IDragHandler
    , IBeginDragHandler, IEndDragHandler
{
    public Vector2 offsetDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 pos = new Vector2(transform.position.x
            , transform.position.y);

        offsetDrag = pos - eventData.position;

        GetComponent<Image>().raycastTarget = false;
        transform.SetAsLastSibling();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + offsetDrag;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
    }
}
