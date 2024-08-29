using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void Activate(Vector2 pos, float halfSizeX)
    {
        transform.position = pos + new Vector2(Random.Range(-halfSizeX, halfSizeX), 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            ScoreManager.Instance.AddBonus(DataBaseManager.Instance.itemBonus, transform.position);
            Destroy(gameObject);
        }
    }
}
