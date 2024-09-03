using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

    [Header("¿¬Ãâ")]
    public Color scoreColor;
    public Color bounsColor;
    public float scorePopInterval = 0.2f;

    [Header("ÇÃ·¹ÀÌ¾î")]
    public float jumpPowerIncrease = 1;
    [Header("ÇÃ·¿Æû")]
    [Tooltip("Å« ÇÃ·¿Æû")]public PlatformPrefab[] largePlatformArr;
    [Tooltip("Áß°£ ÇÃ·¿Æû")] public PlatformPrefab[] middlePlatformArr;
    [Tooltip("ÀÛÀº ÇÃ·¿Æû")] public PlatformPrefab[] smallPlatformArr;
    public PaltformManager.Data[] DataArr;

    [Tooltip("ÇÃ·¿Æû ÃÖ¼Ò °£°Ý")] public float GapIntervalMin = 1.0f;
    [Tooltip("ÇÃ·¿Æû ÃÖ´ë °£°Ý")] public float GapIntervalMax = 2.0f;
    [Tooltip("º¸³Ê½º Ãß°¡ Á¡¼ö")] public float BonusValue = 0.05f;
    [Header("Ä«¸Þ¶ó")]
    public float followSpeed = 5;
    [Header("¾ÆÀÌÅÛ")]
    public Item baseItem;
    public float itemSpawnPer = 0.2f;
    public float itemBonus;

    [Header("»ç¿îµå")]
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
