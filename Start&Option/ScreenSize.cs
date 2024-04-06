using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    private void Start()
    {
        SetResolution();
    }
    //ȭ�� ������ �׻� 16:9
    public void SetResolution()
    {
        Screen.SetResolution(Screen.width, (Screen.width / 16) * 9, true);
    }
}
