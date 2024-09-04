using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;

    public void Init()
    {
        instance = this;
    }

    public void PlaySfx(Define.SfxType sfxType)
    {
        DataBaseManager.SfxData sfxData = DataBaseManager.Instance.GetSfxData(sfxType);
        sfxAudioSource.volume = sfxData.volume;
        sfxAudioSource.PlayOneShot(sfxData.clip);
        
    }
    public void PlayBgm(Define.BgmType type)
    {
        DataBaseManager.BgmData bgmData = DataBaseManager.Instance.GetBgmData(type);
        bgmAudioSource.volume = bgmData.volume;
        bgmAudioSource.clip = bgmData.clip;
        bgmAudioSource.Play();
    }
}
