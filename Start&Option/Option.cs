using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//옵션캔버스 호출 및 최소화
public class Option : MonoBehaviour
{
    public RectTransform rect;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            rect.localScale = Vector3.zero;
    }
    public void Exit()
    {
        SfxManager.instance.PlaySfx(SfxManager.Sfx.Button);
        rect.localScale = Vector3.zero;
    }
    public void CallOption()
    {
        SfxManager.instance.PlaySfx(SfxManager.Sfx.Button);
        rect.localScale = Vector3.one;
    }
}
