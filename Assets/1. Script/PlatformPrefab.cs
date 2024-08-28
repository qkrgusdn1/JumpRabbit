using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPrefab : MonoBehaviour
{
    private BoxCollider2D col;
    [SerializeField] public int score;
    public float HalfSizeX => col.size.x * 0.5f;

    private void Awake()
    {
        col = GetComponentInChildren<BoxCollider2D>();
    }

    public void Active(Vector2 pos)
    {
        transform.position = pos;
    }

    internal void OnLoding()
    {
        ScoreManager.Instance.AddScore(score, transform.position);
    }
}

