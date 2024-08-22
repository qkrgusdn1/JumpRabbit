using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

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

    public void Init()
    {
        Instance = this;
    }
}
