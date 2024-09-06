using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

    [Header("����")]
    public Color scoreColor;
    public Color bounsColor;
    public float scorePopInterval = 0.2f;
    public Effect effect;

    [Header("�÷��̾�")]
    public float jumpPowerIncrease = 1;
    public float GameOverHeight;

    [Header("�÷���")]
    [Tooltip("ū �÷���")]public PlatformPrefab[] largePlatformArr;
    [Tooltip("�߰� �÷���")] public PlatformPrefab[] middlePlatformArr;
    [Tooltip("���� �÷���")] public PlatformPrefab[] smallPlatformArr;
    public PaltformManager.Data[] DataArr;

    [Tooltip("�÷��� �ּ� ����")] public float GapIntervalMin = 1.0f;
    [Tooltip("�÷��� �ִ� ����")] public float GapIntervalMax = 2.0f;
    [Tooltip("���ʽ� �߰� ����")] public float BonusValue = 0.05f;
    [Header("ī�޶�")]
    public float followSpeed = 5;
    [Header("������")]
    public Item baseItem;
    public float itemSpawnPer = 0.2f;
    public float itemBonus;

    [Header("����")]
    public SfxData[] sfxDataArr;
    public BgmData[] bgmDataArr;
    Dictionary<Define.SfxType, SfxData> sfxDataDic;
    Dictionary<Define.BgmType, BgmData> bgmDataDic;
    public void Init()
    {
        Instance = this;

        if (sfxDataArr != null)
        {
            sfxDataDic = new Dictionary<Define.SfxType, SfxData>();
            foreach (SfxData data in sfxDataArr)
            {
                if (data != null) // Ensure data is not null
                {
                    sfxDataDic[data.sfxType] = data;
                }
            }
        }
        else
        {
            Debug.LogError("sfxDataArr is not initialized.");
        }

        if (bgmDataArr != null)
        {
            bgmDataDic = new Dictionary<Define.BgmType, BgmData>();
            foreach (BgmData data in bgmDataArr)
            {
                if (data != null) // Ensure data is not null
                {
                    bgmDataDic[data.bgmType] = data;
                }
            }
        }
        else
        {
            Debug.LogError("bgmDataArr is not initialized.");
        }
    }

    public SfxData GetSfxData(Define.SfxType type)
    {
        return sfxDataDic[type];
    }
    public BgmData GetBgmData(Define.BgmType type)
    {
        return bgmDataDic[type];
    }



    [System.Serializable]
    public class SfxData : SoundData
    {
        public Define.SfxType sfxType;
    }

    [System.Serializable]
    public class BgmData : SoundData
    {
        public Define.BgmType bgmType;
       
    }

    public class SoundData
    {
        public AudioClip clip;
        public float volume = 1; 
    }
}
