using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FixedPiece : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //string log = $"{name}에 드랍됨 ({eventData.pointerDrag.name}";
        //Debug.Log(log, transform);
        //Debug.Log($"드랍된 오브젝트 {eventData.pointerDrag}", eventData.pointerDrag.transform);

        // 위치 스냅.
        eventData.pointerDrag.transform.position = transform.position;

        // 올바른 위치에 드랍되었는지 확인
        if(IsRightPosition(eventData.pointerDrag))
        {
            //// 오바른위치에 드래그됨.
            //번쩍이게 표시하자.
            var dragImage = eventData.pointerDrag.GetComponent<Image>();
            StartCoroutine(BlinkAndDisableClickCo(dragImage, 0.1f));

            ////점수 증가 시키자 - 100점 올리기
            //GameManager.Instance.AddScore(100);
        }
    }

    private IEnumerator BlinkAndDisableClickCo(Image dragImage, float time)
    {
        dragImage.color = Color.red;
        yield return new WaitForSeconds(time);
        dragImage.color = Color.white;

        // 정상위치에 드래그 된건 움직이지 못하게 하자.
        dragImage.raycastTarget = false;
    }

    private bool IsRightPosition(GameObject dragObject)
    {
        // dragObject.name -> "3:2 (1)"
        var dragObjectName = dragObject.name.Replace(" (1)", "");
        return name.CompareTo(dragObjectName) == 0;
    }
}
