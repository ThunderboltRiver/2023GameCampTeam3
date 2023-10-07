using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Timer m_Time;   //�^�C�}�[�̏��

    [SerializeField]
    private Score m_score;  //�X�R�A�̏��

    void Start()
    {
        //�t���[�����[�g�Œ�
        Application.targetFrameRate = 60;

        //������
        InitGame();
    }

    void Update()
    {
        //�Q�[���N���A�̏�����

        
        if(m_Time.IsTimeOut() && m_score.IsLow(10))
        {
            Debug.Log("�Q�[���I�[�o�[");
        }

        //�Q�[���I�[�o�[�̏�����

        if (Input.GetKeyDown(KeyCode.Escape))
        {//ESC�L�[�������ꂽ�Ƃ�
            //�Q�[���I��
            Quit();
        }
    }

    void InitGame()
    {//���̏�����
        
    }

    void Quit()
    {//�A�v���̏I������
#if UNITY_ENGINE
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
#endif
    }
}
