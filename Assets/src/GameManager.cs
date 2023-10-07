using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Timer m_Time;   //タイマーの情報

    [SerializeField]
    private Score m_score;  //スコアの情報

    void Start()
    {
        //フレームレート固定
        Application.targetFrameRate = 60;

        //初期化
        InitGame();
    }

    void Update()
    {
        //ゲームクリアの条件式

        
        if(m_Time.IsTimeOut() && m_score.IsLow(10))
        {
            Debug.Log("ゲームオーバー");
        }

        //ゲームオーバーの条件式

        if (Input.GetKeyDown(KeyCode.Escape))
        {//ESCキーが押されたとき
            //ゲーム終了
            Quit();
        }
    }

    void InitGame()
    {//情報の初期化
        
    }

    void Quit()
    {//アプリの終了処理
#if UNITY_ENGINE
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
#endif
    }
}
