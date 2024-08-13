using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager instance;
    [SerializeField] Player player;

    public GameManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
        player.Init();
    }
}
