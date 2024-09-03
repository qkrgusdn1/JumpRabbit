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

    [Header("�÷��̾�")]
    public float jumpPowerIncrease = 1;
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
    Dictionary<Define.SfxType, SfxData> sfxDataDic = new Dictionary<Define.SfxType, SfxData> ();
    public void Init()
    {
        Instance = this;

        foreach(SfxData data in sfxDataArr)
        {
            sfxDataDic.Add(data.sfxType, data);
        }
    }

    public SfxData GetSfxData(Define.SfxType type)
    {
        return sfxDataDic[type];
    }

    [System.Serializable]
    public class SfxData
    {
        public Define.SfxType sfxType;
        public AudioClip clip;
    }

    [System.Serializable]
    public class BgmData
    {
        public Define.BgmType bgmType;
        public AudioClip clip;
    }
}
