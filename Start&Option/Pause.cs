using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//일시정지 및 옵션
public class Pause : MonoBehaviour
{
    public RectTransform rect;
    SoundOptions soundOptions;

    private void Awake()
    {
        if (GameObject.Find("SoundManager") != null)
        {
            soundOptions = GameObject.Find("SoundManager").GetComponent<SoundOptions>();
        }
    }

    public void CallMenu()
    {
        if (GameObject.Find("SoundManager") != null)
        {
            soundOptions.delete();
        }
        SfxManager.instance.PlaySfx(SfxManager.Sfx.Button);
        rect.localScale = Vector3.one;
        Time.timeScale = 0.0f;
    }
    public void ClosedMenu()
    {
        SfxManager.instance.PlaySfx(SfxManager.Sfx.Button);
        rect.localScale = Vector3.zero;
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
    public void ToLobby()
    {
        SfxManager.instance.PlaySfx(SfxManager.Sfx.Button);
        SceneManager.LoadScene("Lobby");
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    public void Restart()
    {
        SfxManager.instance.PlaySfx(SfxManager.Sfx.Button);
        rect.localScale = Vector3.zero;
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        SceneManager.LoadScene("Stage");
    }
}
