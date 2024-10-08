using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaltformManager : MonoBehaviour
{
    public static PaltformManager instance;

    [SerializeField] Transform spawnPosTr;
    
    public int platformNum = 0;
    public int landingPlatformNum;

    Vector3 pos;

    Dictionary<int, PlatformPrefab[]> platformArrDic = new Dictionary<int, PlatformPrefab[]>();
    [System.Serializable]
    public class Data
    {
        public int GroupCount;
        [Tooltip("ū �÷��� ����(0~1.0)"), Range(0,1)][SerializeField] private float LargePercent;
        [Tooltip("�߰� �÷��� ����(0~1.0)"), Range(0, 1)][SerializeField] private float MiddlePercent;
        [Tooltip("���� �÷��� ����(0~1.0)"), Range(0, 1)][SerializeField] private float SmallPercent;

        public int GetPlatformID()
        {
            float randVal = Random.value;
            int platformID;
            if (randVal <= LargePercent)
            {
                platformID = 0;
            }
            else if (randVal <= LargePercent + MiddlePercent)
            {
                platformID = 1;
            }
            else
            {
                platformID = 2;
            }
            return platformID;
        }
    }

    private void Update()
    {
        if(platformNum - landingPlatformNum < DataBaseManager.Instance.remainPlatformCount)
        {
            int lastIndex = DataBaseManager.Instance.DataArr.Length - 1;
            Data lastData = DataBaseManager.Instance.DataArr[lastIndex];

            for (int i = 0; i < lastData.GroupCount; i++)
            {
                int platformID = lastData.GetPlatformID();
                ActiveOne(platformID);
            }
        }
    }
    internal void Active()
    {
        pos = spawnPosTr.position;
        int platformGroupSum = 0;
        foreach (Data data in DataBaseManager.Instance.DataArr)
        {
            platformGroupSum += data.GroupCount;
            while (platformNum < platformGroupSum)
            {
                int platformID = data.GetPlatformID();
                ActiveOne(platformID);
                
            }
        }
    }

    internal void Init()
    {
        instance = this;
        platformArrDic.Add(0, DataBaseManager.Instance.largePlatformArr);
        platformArrDic.Add(1, DataBaseManager.Instance.middlePlatformArr);
        platformArrDic.Add(2, DataBaseManager.Instance.smallPlatformArr);
    }
    private void ActiveOne(int platformID)
    {
        platformNum++;
        PlatformPrefab[] platforms = platformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        PlatformPrefab randomPlatform = platforms[randID];

        Debug.Log($"Platform [{platformID}, {randID}], platforms.length: {platforms.Length}, randomPlatform: {randomPlatform}");

        PlatformPrefab platform = Instantiate(randomPlatform);

        if (platformNum > 1)
            pos = pos + Vector3.right * platform.HalfSizeX;

        platform.Active(pos, platformNum);

        float gap = Random.Range(DataBaseManager.Instance.GapIntervalMin, DataBaseManager.Instance.GapIntervalMax);
        pos += Vector3.right * (platform.HalfSizeX + gap);
        return;
    }
}
