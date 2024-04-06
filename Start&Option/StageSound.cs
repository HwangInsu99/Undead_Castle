using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
//옵션의 사운드를 참조해와서 게임의 소리조절(로비씬에서 조절한값과 연동)
public class StageSound : MonoBehaviour
{
    public static StageSound instance;

    public AudioMixer mixer;

    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    public float x;
    public float y;
    public float z;

    SoundOptions soundOptions;
    void Awake()
    {
        if (GameObject.Find("SoundManager") != null)
        {
            soundOptions = GameObject.Find("SoundManager").GetComponent<SoundOptions>();
            x = soundOptions.ma;
            y = soundOptions.bg;
            z = soundOptions.sf;
        }
        masterSlider.value = x;
        bgmSlider.value = y;
        sfxSlider.value = z;
        DontDestroyOnLoad(gameObject);
    }

    public void SetMasterVolume()
    {
        mixer.SetFloat("Master", Mathf.Log10(masterSlider.value) * 20);
        x = masterSlider.value;
    }
    public void SetBgmVolume()
    {
        mixer.SetFloat("BGM", Mathf.Log10(bgmSlider.value) * 20);
        y = bgmSlider.value;
    }
    public void SetSfxVolume()
    {
        mixer.SetFloat("SFX", Mathf.Log10(sfxSlider.value) * 20);
        z = sfxSlider.value;
    }
    public void delete()
    {
        Destroy(gameObject);
    }
}
