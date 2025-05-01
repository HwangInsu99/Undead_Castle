using UnityEngine;
using UnityEngine.SceneManagement;
//일시정지 및 옵션
public class Pause : MonoBehaviour
{
    public RectTransform rect;

    public void CallMenu()
    {
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
