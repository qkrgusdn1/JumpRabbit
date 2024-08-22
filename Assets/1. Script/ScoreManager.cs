using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    int totalScore;
    [SerializeField] TMP_Text scoreTmp;
    [SerializeField] Score bestScore;
    public void Init()
    {
        Instance = this;
    }

    internal void AddBonus(float bonusValue, Vector3 position)
    {

    }

    internal void ResetBonus()
    {

    }

    public void AddScore(int score, Vector2 scorePos)
    {
        Debug.Log($"Platform position: {scorePos}");
        Score scoreObject = Instantiate(bestScore);
        scoreObject.transform.position = scorePos;
        scoreObject.Active(score);
        totalScore += score;
        scoreTmp.text = totalScore.ToString();
    }
}
