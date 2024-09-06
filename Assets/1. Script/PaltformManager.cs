using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaltformManager : MonoBehaviour
{
    [SerializeField] Transform spawnPosTr;
    
    private int platformNum = 0;

    

    Dictionary<int, PlatformPrefab[]> platformArrDic = new Dictionary<int, PlatformPrefab[]>();
    [System.Serializable]
    public class Data
    {
        public int GroupCount;
        [Tooltip("Å« ÇÃ·¿Æû ºñÀ²(0~1.0)"), Range(0,1)][SerializeField] private float LargePercent;
        [Tooltip("Áß°£ ÇÃ·¿Æû ºñÀ²(0~1.0)"), Range(0, 1)] private float MiddlePercent;
        [Tooltip("ÀÛÀº ÇÃ·¿Æû ºñÀ²(0~1.0)"), Range(0, 1)] private float SmallPercent;

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
    internal void Active()
    {
        Vector3 pos = spawnPosTr.position;
        int platformGroupSum = 0;
        foreach (Data data in DataBaseManager.Instance.DataArr)
        {
            platformGroupSum += data.GroupCount;
            while (platformNum < platformGroupSum)
            {
                int platformID = data.GetPlatformID();
                pos = ActiveOne(pos, platformID);
                platformNum++;
            }
        }
    }

    internal void Init()
    {
        platformArrDic.Add(0, DataBaseManager.Instance.largePlatformArr);
        platformArrDic.Add(1, DataBaseManager.Instance.middlePlatformArr);
        platformArrDic.Add(2, DataBaseManager.Instance.smallPlatformArr);
    }
    private Vector3 ActiveOne(Vector3 pos, int platformID)
    {
        PlatformPrefab[] platforms = platformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        PlatformPrefab randomPlatform = platforms[randID];

        Debug.Log($"Platform [{platformID}, {randID}], platforms.length: {platforms.Length}, randomPlatform: {randomPlatform}");

        PlatformPrefab platform = Instantiate(randomPlatform);

        bool isFirstFrame = platformNum == 0;
        if(isFirstFrame == false)
        {
            pos = pos + Vector3.right * platform.HalfSizeX;
        }

        platform.Active(pos, isFirstFrame);

        float gap = Random.Range(DataBaseManager.Instance.GapIntervalMin, DataBaseManager.Instance.GapIntervalMax);
        pos += Vector3.right * (platform.HalfSizeX + gap);
        return pos;
    }
}
