using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    int totalScore;
    float totalBouns;
    [SerializeField] TMP_Text scoreTmp;
    [SerializeField] private TMP_Text bounsTmp;
    [SerializeField] Score baseScore;
    List<ScoreData> scoreDataList = new List<ScoreData>();

    public void Init()
    {
        Instance = this;
        StartCoroutine(OnScoreCor());
    }

    IEnumerator OnScoreCor()
    {
        while (true)
        {
            if(scoreDataList.Count > 0)
            {
                ScoreData data = scoreDataList[0];
                Score scoreObj = Instantiate<Score>(baseScore);
                scoreObj.transform.position = data.pos;
                scoreObj.Active(data.str, data.color);

                scoreDataList.RemoveAt(0);
                yield return new WaitForSeconds(DataBaseManager.Instance.scorePopInterval);
            }
            else
            {
                yield return null;
            }
            
        }
    }

    internal void AddBonus(float bouns, Vector3 position)
    {
        totalBouns += bouns;
        bounsTmp.text = totalBouns.ToPercentString();
        scoreDataList.Add(new ScoreData()
        {
            str = "Bouns" + bounsTmp.text,
            color = DataBaseManager.Instance.bounsColor,
            pos = position,
        });
        
    }

    struct ScoreData
    {
        public string str;
        public Color color;
        public Vector2 pos;
    }

    internal void ResetBonus(Vector2 bounsPos)
    {
        scoreDataList.Add(new ScoreData()
        {
            str = "Bouns 초기화...",
            color = DataBaseManager.Instance.bounsColor,
            pos = bounsPos
        });

        totalBouns = 0;
        bounsTmp.text = totalBouns.ToPercentString();
    }

    public void AddScore(int score, Vector2 scorePos, bool isCalBonus = true)
    {
        //애니
        scoreDataList.Add(new ScoreData()
        {
            str = score.ToString(),
            color = DataBaseManager.Instance.scoreColor,
            pos = scorePos
        });

        totalScore += score;
        scoreTmp.text = totalScore.ToString();

        if (isCalBonus)
        {
            int bounsScore = (int)(score * totalBouns);
            AddScore(bounsScore, scorePos, false);
        }
    }
}
