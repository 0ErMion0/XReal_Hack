using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Chapter5Sys : MonoBehaviour
{
    public static Chapter5Sys instance5;

    private void Awake()
    {
        if (instance5 == null)
        {
            instance5 = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    // 대사
    [SerializeField] GameObject textImg;
    public TMP_Text tmp;
    private int speechIndex = 0;

    // 자리 선택
    public int currentPersonIndex;
    int seatIndex = 0;


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

    public void onSelectedSeat()
    {
        switch (seatIndex)
        {
            case 0:
                // 카르센사 대표님 그 자리에 앉히기
                // - 부장님 자세 애니메이션으로 바꾸기
                // - 부장님 위치 의자 위로 변경
                // - 부장님 머리 위 정팔면체 없애기
                // - 앉은 의자 선택 시 색 변경하는거 없애기
                // - 앉은 의자 위 원뿔 없애기

                break;
            case 1:
                // 카르센사 대리님 그 자리에 앉히기

                break;
            case 2:
                // 카르센사 사원님 그 자리에 앉히기

                break;
            case 3:
                // 박님 그 자리에 앉히기

                break;
            case 4:
                // 정님 그 자리에 앉히기

                break;
        }
    }

    public void changeCurrentPersonIndex()
    {
        currentPersonIndex++;
    }

}
