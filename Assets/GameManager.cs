using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    public int currentScore;
    public int comepleteScore;
    internal void AddScore(int addScore)
    {
        currentScore += addScore;

        if(comepleteScore == currentScore)
        {
            ToastMessage.Instance.ShowToast("스테이지 클리어");
        }
    }
}
