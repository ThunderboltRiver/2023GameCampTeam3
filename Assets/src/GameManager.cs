using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Timer m_Time;

    [SerializeField]
    private Score m_score;

    void Start()
    {
        Application.targetFrameRate = 60;
        InitGame();
    }

    void Update()
    {   
        if(m_Time.IsTimeOut() && m_score.IsLow(10))
        {
            Debug.Log("a");
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
