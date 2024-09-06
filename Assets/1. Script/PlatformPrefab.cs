using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPrefab : MonoBehaviour
{
    private BoxCollider2D col;
    [SerializeField] public int score;
    public float HalfSizeX => col.size.x * 0.5f;
    Animation ani;

    private void Awake()
    {
        col = GetComponentInChildren<BoxCollider2D>();
        ani = GetComponentInChildren<Animation>();
    }

    public void Active(Vector2 pos, bool isFirstFrame)
    {
        transform.position = pos;

        if (isFirstFrame)
            return;

        if(Random.value < DataBaseManager.Instance.itemSpawnPer)
        {
            Item item = Instantiate<Item>(DataBaseManager.Instance.baseItem);
            item.Activate(transform.position, 0.5f);
        }    
    }

    internal void OnLoding()
    {
        ScoreManager.Instance.AddScore(score, transform.position);
    }
    internal void OnLodingAnimation()
    {
        ani.Play();
    }
}

