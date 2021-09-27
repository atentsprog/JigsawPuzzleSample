using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        for (int y = 0; y < yCount; y++)
        {
            for (int x = 0; x < xCount; x++)
            {
                var item = new GameObject($"{x}:{y}");
                item.transform.parent = transform;
                RectTransform rt = item.AddComponent<RectTransform>();
                // 크기
                rt.sizeDelta = new Vector2(pieceWidth, pieceHeight);

                // 위치.
                float xPos = x * pieceWidth;
                float yPos = -y * pieceHeight;
                item.transform.localPosition = new Vector3(xPos, yPos, 0);

                item.AddComponent<Image>().sprite = sprites[imageIndex];
                imageIndex++;
            }
        }
    }

    private void DeleteOldPiece()
    {
        var childs = transform.GetComponentsInChildren<Image>();
        foreach (var item in childs)
            DestroyImmediate(item.gameObject);
    }
}
