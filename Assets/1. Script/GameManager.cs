using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Player player;
    [SerializeField] private PaltformManager platformManager;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private DataBaseManager dataBaseManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject retryBtn;

    private void Awake()
    {
        instance = this;  
        scoreManager.Init();
        dataBaseManager.Init();
        player.Init();
        
        platformManager.Init();
        
        cameraManager.Init();
        soundManager.Init();
    }

    public void CallBtnRetry()
    {
        SceneManager.LoadScene(0);
    }

    public void OnGameOver()
    {
        retryBtn.SetActive(true);
    }

    private void Start()
    {
        platformManager.Active();
        soundManager.PlayBgm(Define.BgmType.Main);
        scoreManager.Active();
    }
}
