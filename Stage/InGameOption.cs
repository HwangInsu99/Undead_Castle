using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//레벨업 시 업그레이드 선택창 작동확인용
/*
public class InGameOption : MonoBehaviour
{
    public int click;
    void Start()
    {
        click = 0;
    }
    public void Pause()
    {
        if (click == 0)
        {
            click = 1;
            GameManager.instance.Levelup();
            Time.timeScale = 0.0f;
        }
        else
        {
            click = 0;
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
    }
}
*/