using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 화면 중앙에 표시하자.
/// 피스를 드래그 시키자.
/// </summary>
public class PuzzlePiecePosInit : MonoBehaviour
{
    public List<Sprite> sprites;
    public int xCount = 4;
    public int yCount = 3;

    private void Awake()
    {
        InitPosition();
    }

    [ContextMenu("퍼즐 배치")]
    private void InitPosition()
    {
        DeleteOldPiece();
        float pieceWidth = sprites[0].textureRect.width;
        float pieceHeight = sprites[0].textureRect.height;

        int imageIndex = 0;
        for (int y = 1; y <= yCount; y++)
        {
            for (int x = 1; x <= xCount; x++)
            {
                var item = new GameObject($"{x}:{y}", typeof(FixedPiece));
                item.transform.parent = transform;
                item.transform.localScale = Vector3.one;
                RectTransform rt = item.AddComponent<RectTransform>();
                // 크기
                rt.sizeDelta = new Vector2(pieceWidth, pieceHeight);

                // 위치.
                float xPos = (x - xCount) * (pieceWidth * 0.5f) + (x - 1) * (pieceWidth * 0.5f);
                float yPos = -(y - yCount) * (pieceHeight * 0.5f) + -(y - 1) * (pieceHeight * 0.5f);

                item.transform.localPosition = new Vector3(xPos, yPos, 0);

                item.AddComponent<Image>().sprite = sprites[imageIndex];
                imageIndex++;
            }
        }

        GameManager.Instance.comepleteScore = sprites.Count * 100;
    }

    private void DeleteOldPiece()
    {
        var childs = transform.GetComponentsInChildren<Image>();
        foreach (var item in childs)
        {
            if(Application.isPlaying)
                Destroy(item.gameObject);
            else
                DestroyImmediate(item.gameObject);
        }
    }
}
