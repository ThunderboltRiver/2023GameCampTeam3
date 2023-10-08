using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Timer m_Time;

    [SerializeField]
    private Score m_score;

    [SerializeField]
    private TextMeshProUGUI resultsText;

    [SerializeField]
    private TextMeshProUGUI targetScoreText;

    [SerializeField]
    private int targetScore = 1000;

    void Start()
    {
        Application.targetFrameRate = 60;
        targetScoreText.text = $"TargetScore{targetScore}".ToString();
        InitGame();
    }

    void Update()
    {
        if (!m_Time.IsTimeOut()) return;
        if (m_score.IsLow(targetScore))
        {
            resultsText.text = "GAME OVER";
        }
        if (!m_score.IsLow(targetScore))
        {
            resultsText.text = "GAME CLEAR";
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    void InitGame()
    {
        
    }

    void Quit()
    {
#if UNITY_ENGINE
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
#endif
    }
}
