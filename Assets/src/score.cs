using UnityEngine;
using TMPro;
public class Score : MonoBehaviour

{
    [SerializeField]
    private TextMeshProUGUI testText;
    private int _myScore = 0;

    void Start()
    {
        testText.text = $"Score\n{_myScore}";
    }
    public int AddScores(int addScores)
    {
        _myScore += addScores;
        testText.text = $"Score\n{_myScore}";

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