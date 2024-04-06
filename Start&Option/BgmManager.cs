using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BgmManager : MonoBehaviour
{
    public static BgmManager instance;

    [Header("#BGM")]
    public AudioClip[] bgmClips;
    public float bgmVolume;
    public int channels;
    AudioSource[] bgmPlayers;
    int channelIndex;
    public AudioMixer mixer;

    public enum Bgm { Normal, Boss }
    private void Awake()
    {
        instance = this;
        Init();
    }
    void Init()
    {
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayers = new AudioSource[channels];

        for (int index = 0; index < bgmPlayers.Length; index++)
        {
            bgmPlayers[index] = bgmObject.AddComponent<AudioSource>();
            bgmPlayers[index].playOnAwake = false;
            bgmPlayers[index].loop = true;
            bgmPlayers[index].outputAudioMixerGroup = mixer.FindMatchingGroups("BGM")[0];
            bgmPlayers[index].volume = bgmVolume;
        }
        PlayBgm(Bgm.Normal);
    }

    public void PlayBgm(Bgm bgm)
    {
        bgmPlayers[0].clip = bgmClips[(int)bgm];
        bgmPlayers[0].Play();
    }
}
