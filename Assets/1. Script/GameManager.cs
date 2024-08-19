using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PaltformManager platformManager;
    [SerializeField] private CameraManager cameraManager;

    private void Awake()
    {
        player.Init();
        platformManager.Init();
        cameraManager.Init();
    }

    private void Start()
    {
        platformManager.Active();
    }
}
