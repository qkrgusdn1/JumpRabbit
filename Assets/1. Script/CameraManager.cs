using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bgSrdr;
    public static CameraManager Instance;
    float cameraWidth;

    public void Init()
    {
        Instance = this;
        Camera camera = Camera.main;
        float cameraHeight = camera.orthographicSize * 2f;
        cameraWidth = cameraHeight * camera.aspect;
    }

    public void OnFollow(Vector2 targetPos)
    {
        StartCoroutine(OnFollowCar(targetPos));
    }

    IEnumerator OnFollowCar(Vector2 targetPos)
    {
        while(0.1f < Vector3.Distance(transform.position, targetPos))
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * DataBaseManager.Instance.followSpeed);

            float bgRightX = bgSrdr.transform.position.x + bgSrdr.size.x /2;
            float cameraRightX = Camera.main.transform.position.x + cameraWidth * 2;
            if(bgRightX <= cameraRightX)
            {
                bgSrdr.size = new Vector2(bgSrdr.size.x + cameraWidth * 2,bgSrdr.size.y);
            }

            yield return null;
        }
    }
}
