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

    public void Active(int score)
    {
        tmp.text = score.ToString();
    }

    public void Deactive()
    {
        Destroy(gameObject);
    }

}
