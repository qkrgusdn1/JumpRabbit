using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class MyExtension
{
    public static string ToFormatString(this float value, int pointNum = 0)
    {
        if (pointNum == 0) return string.Format("{0:N0}", value);
        else if (pointNum == 1) return string.Format("{0:N1}", value);
        else if (pointNum == 2) return string.Format("{0:N1}", value);
        else if (pointNum == 3) return string.Format("{0:N1}", value);
        else return value.ToString();
    }
}
