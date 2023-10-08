using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float fSeconds;     //�^�C���̒l

    [SerializeField]
    public TextMeshProUGUI Timertext;  //�^�C�}�[�̃e�L�X�g

    public bool IsTimeOut()
    {
        return fSeconds <= 0;

    }
    void Start()
    {
        //�e�L�X�g�ɒl����
        Timertext.text = fSeconds.ToString();
    }

    void Update()
    {
        //���Ԍ��Z
        if(fSeconds > 0)
            fSeconds -= Time.deltaTime;
        //�\�����鎞��
        Timertext.text = (Mathf.Round(fSeconds * 1) / 1).ToString();
    }
    public void AddTime(int seconds)
    {
        fSeconds += seconds;
        Timertext.text = (Mathf.Round(fSeconds * 1) / 1).ToString();

    }
}
