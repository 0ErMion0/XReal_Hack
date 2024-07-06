using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chapter5Sys : MonoBehaviour
{
    // 대사
    [SerializeField] GameObject textImg;
    public TMP_Text tmp;
    private int speechIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        textImg.SetActive(true);

        // 띵동
        SoundManager._instance.PlaySoundCor(Define.ch5KnockingVfx, OnSpeechComplete0);

    }

    // 대사
    void Speech()
    {
        textImg.SetActive(true);
        switch (speechIndex)
        {
            case 0:
                tmp.text = "클라이언트 분들 오셨나보다!";
                SoundManager._instance.PlaySoundCor(Define.ch5Conversation_1, OnSpeechComplete1);
                //speechIndex++;
                break;
            case 1:
                tmp.text = "어떻게 앉는게 좋을까?";
                SoundManager._instance.PlaySoundCor(Define.ch5Conversation_2, OnSpeechComplete2);
                speechIndex = 0;
                break;
        }
    }

    void OnSpeechComplete0()
    {
        Speech();
    }

    void OnSpeechComplete1()
    {
        speechIndex++;
        Speech();
    }

    void OnSpeechComplete2()
    {
        textImg.SetActive(false);

        // 자리 선택 시작
    }


}
