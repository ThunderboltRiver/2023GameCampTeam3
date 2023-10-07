using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField]
    private float fSeconds;     //タイムの値

    [SerializeField]
    public TextMeshProUGUI Timertext;  //タイマーのテキスト

    void Start()
    {
        //テキストに値を代入
        Timertext.text = fSeconds.ToString();
    }

    void Update()
    {
        //時間減算
        fSeconds -= Time.deltaTime;

        //表示する時間
        Timertext.text = (Mathf.Round(fSeconds * 1) / 1).ToString();
    }
}
