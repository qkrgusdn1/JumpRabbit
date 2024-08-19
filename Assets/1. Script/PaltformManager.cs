using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaltformManager : MonoBehaviour
{
    [SerializeField] Transform spawnPosTr;
    [SerializeField] Platform[] largePlatformArr;
    [SerializeField] Platform[] middlePlatformArr;
    [SerializeField] Platform[] smallPlatformArr;
    [SerializeField] private Transform spawnPosTrf;
    [SerializeField] private Platform[] LargePlatformArr;
    [SerializeField] private Platform[] MiddlePlatformArr;
    [SerializeField] private Platform[] SmallPlatformArr;
    [SerializeField] private Data[] DataArr;
    private int platformNum = 0;

    [SerializeField] private float GapIntervalMin = 1.0f;
    [SerializeField] private float GapIntervalMax = 2.0f;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();
    Dictionary<int, Platform[]> platformArrDic = new Dictionary<int, Platform[]>();
    [System.Serializable]
    public class Data
    {
        public int GroupCount;
        [SerializeField] private float LargePercent;
        [SerializeField] private float MiddlePercent;
        [SerializeField] private float SmallPercent;

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
        platformArrDic.Add(0, smallPlatformArr);
        platformArrDic.Add(1, middlePlatformArr);
        platformArrDic.Add(2, largePlatformArr);
    }

    internal void Init() 
    {
        Platform[] platforms = platformArrDic[2];

        Platform platform = platforms[Random.Range(0, platforms.Length)];
        Platform platform1 = Instantiate(platform);
        platform1.Active(spawnPosTr.position);
    }
    private Vector3 ActiveOne(Vector3 pos, int platformID)
    {
        Platform[] platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        Platform randomPlatform = platforms[randID];
        Debug.Log($"Platform [{platformID}, {randID}]");

        Platform platform = Instantiate(randomPlatform);

        if (platformNum != 0)
        {
            pos += Vector3.right * platform.HalfSizeX;
        }

        platform.Active(pos);

        float gap = Random.Range(GapIntervalMin, GapIntervalMax);
        pos += Vector3.right * (platform.HalfSizeX + gap);
        return pos;
    }
}
