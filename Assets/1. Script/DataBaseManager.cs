using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

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

    public void Init()
    {
        Instance = this;
    }
}
