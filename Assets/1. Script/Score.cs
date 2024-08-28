using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VisionOS;
using UnityEngine;

public class Score : MonoBehaviour
{
    TextMeshPro tmp;


    private void Awake()
    {
        tmp = GetComponentInChildren<TextMeshPro>();
    }

    public void Active(string scoreTxt, Color color)
    {
        tmp.text = scoreTxt;
        tmp.color = color;
    }

    public void Deactive()
    {
        Destroy(gameObject);
    }

}
