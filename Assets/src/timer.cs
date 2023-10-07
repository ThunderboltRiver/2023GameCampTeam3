using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField]
    private float fSeconds;     //�^�C���̒l

    [SerializeField]
    public TextMeshProUGUI Timertext;  //�^�C�}�[�̃e�L�X�g

    void Start()
    {
        //�e�L�X�g�ɒl����
        Timertext.text = fSeconds.ToString();
    }

    void Update()
    {
        //���Ԍ��Z
        fSeconds -= Time.deltaTime;

        //�\�����鎞��
        Timertext.text = (Mathf.Round(fSeconds * 1) / 1).ToString();
    }
}
