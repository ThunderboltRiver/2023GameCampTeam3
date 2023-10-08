using UnityEngine;
using TMPro;
public class Score : MonoBehaviour

{
    [SerializeField]
    private TextMeshProUGUI testText;
    private int _myScore = 0;

    void Start()
    {
        testText.text = $"Score:{_myScore}";
    }
    public int AddScores(int addSores)
    {
        _myScore += addSores;
        testText.text =$"Score:{_myScore}";
        
        return _myScore;
    }
    //?X?R?A???????t?B?[?h????
    //?X?R?A???v???X??????

    public bool IsLow(int Score)
    {
        return _myScore < Score;
    }
    //?X?R?A????
}