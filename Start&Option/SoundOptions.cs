using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
//옵션의 사운드조절(슬라이드바)
public class SoundOptions : MonoBehaviour
{
    public static SoundOptions instance;

    public AudioMixer mixer;

    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    public float ma = 0.5f;
    public float bg = 0.5f;
    public float sf = 0.3f;

    StageSound stageSound;
    void Awake()
    {
        if(GameObject.Find("StageSound") != null)
        {
            stageSound = GameObject.Find("StageSound").GetComponent<StageSound>();
            ma = stageSound.x;
            bg = stageSound.y;
            sf = stageSound.z;
        }
        masterSlider.value = ma;
        bgmSlider.value = bg;
        sfxSlider.value = sf;
        DontDestroyOnLoad(gameObject);
    }

    public void SetMasterVolume()
    {
        mixer.SetFloat("Master", Mathf.Log10(masterSlider.value) * 20);
        ma = masterSlider.value;
    }
    public void SetBgmVolume()
    {
        mixer.SetFloat("BGM", Mathf.Log10(bgmSlider.value) * 20);
        bg = bgmSlider.value;
    }
    public void SetSfxVolume()
    {
        mixer.SetFloat("SFX", Mathf.Log10(sfxSlider.value) * 20);
        sf = sfxSlider.value;
    }
    public void delete()
    {
        Destroy(gameObject);
    }
}
