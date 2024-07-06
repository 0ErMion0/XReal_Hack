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
        tmp.text = "드디어 퇴근이다! 먼저 들어가보겠습니다~";
        SoundManager._instance.PlaySoundCor(Define.ch6ClockVfx, OnSpeechComplete0);
    }
    void OnSpeechComplete0()
    {
        // 성적표 ui 출력
        textImg.SetActive(false);
        getScore();
        goScore.SetActive(true);
    }

    void getScore()
    {
        ch1Tmp.text = ScoreMng.main.ch1Score.ToString() + "만원";
        ch2Tmp.text = ScoreMng.main.ch3Score.ToString() + "만원";
        ch4Tmp.text = ScoreMng.main.ch4Score.ToString() + "만원";
        ch5Tmp.text = ScoreMng.main.ch5Score.ToString() + "만원";
        totalTmp.text = ScoreMng.main.totalScore.ToString() + "만원";
    }
}
