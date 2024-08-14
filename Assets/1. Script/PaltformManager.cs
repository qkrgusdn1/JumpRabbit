using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaltformManager : MonoBehaviour
{
    [SerializeField] Transform spawnPosTr;
    [SerializeField] Platform[] largePlatformArr;
    [SerializeField] Platform[] middlePlatformArr;
    [SerializeField] Platform[] smallPlatformArr;

    Dictionary<int, Platform[]> platformArrDic = new Dictionary<int, Platform[]>();

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
}
