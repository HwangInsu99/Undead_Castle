using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyS : MonoBehaviour
{
    public Option option;

    StageSound stageSound;
    private void Awake()
    {
        if (GameObject.Find("StageSound") != null)
        {
            stageSound = GameObject.Find("StageSound").GetComponent<StageSound>();
            stageSound.delete();
        }
    }
    public void ToStage()
    {
        SfxManager.instance.PlaySfx(SfxManager.Sfx.Button);
        SceneManager.LoadScene("Stage");
    }
    public void ToOption()
    {
        SfxManager.instance.PlaySfx(SfxManager.Sfx.Button);
        option.CallOption();
    }
    public void Exit()
    {
        SfxManager.instance.PlaySfx(SfxManager.Sfx.Button);
        Application.Quit();
    }
}