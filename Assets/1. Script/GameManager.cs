using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PaltformManager platformManager;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private DataBaseManager dataBaseManager;
    [SerializeField] private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager.Init();
        dataBaseManager.Init();
        player.Init();
        
        platformManager.Init();
        platformManager.Active();
        cameraManager.Init();
       
    }
}
