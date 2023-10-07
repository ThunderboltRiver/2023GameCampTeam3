using UnityEngine;
using TMPro;
public class Score : MonoBehaviour

{
    [SerializeField]
    private TextMeshProUGUI testText;


    private int _myScore = 0;
    int AddScores(int addSores)
    {
        _myScore += addSores;
        testText.text =_myScore.ToString();
        
        return _myScore;
    }
    //スコア管理のフィード変数
    //スコアがプラスされる

    public bool IsLow(int Score)
    {
        return _myScore < Score;
    }
    //スコア判定
}