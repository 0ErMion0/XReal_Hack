using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetScore : MonoBehaviour
{
    public TMP_Text tmp;

    public TMP_Text ch1Tmp;
    public TMP_Text ch2Tmp;
    public TMP_Text ch4Tmp;
    public TMP_Text ch5Tmp;
    public TMP_Text totalTmp;

    public GameObject goScore;
    [SerializeField] GameObject textImg;

    // Start is called before the first frame update
    void Start()
    {
        textImg.SetActive(true);
        //SoundManager._instance.PlaySoundCor(Define.ch6ClockVfx);

        Speech();
    }

    void Speech()
    {
        tmp.text = "���� ����̴�! ���� �����ڽ��ϴ�~";
        SoundManager._instance.PlaySoundCor(Define.ch6ClockVfx, OnSpeechComplete0);
    }
    void OnSpeechComplete0()
    {
        // ����ǥ ui ���
        textImg.SetActive(false);
        getScore();
        goScore.SetActive(true);
    }

    void getScore()
    {
        ch1Tmp.text = ScoreMng.main.ch1Score.ToString() + "����";
        ch2Tmp.text = ScoreMng.main.ch3Score.ToString() + "����";
        ch4Tmp.text = ScoreMng.main.ch4Score.ToString() + "����";
        ch5Tmp.text = ScoreMng.main.ch5Score.ToString() + "����";
        totalTmp.text = ScoreMng.main.totalScore.ToString() + "����";
    }
}
