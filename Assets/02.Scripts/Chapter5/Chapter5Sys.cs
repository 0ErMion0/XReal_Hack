using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using System.Linq;

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
    public int currentPersonIndex = 0;
    int seatIndex = 0;
    bool b_PersonEmpty = false;

    // 비교
    public string[] arr_answerSeat = { "A", "B", "C", "D", "E" };
    public string[] arr_chairName = new string[5];

    // Start is called before the first frame update
    void Start()
    {
        textImg.SetActive(true);

        // 배열 초기화
        arr_chairName = new string[arr_answerSeat.Length];

        // 띵동
        SoundManager._instance.PlaySoundCor(Define.ch5KnockingVfx, OnSpeechComplete0);

    }

    private void Update()
    {
        if(currentPersonIndex >= 5 && !b_PersonEmpty)
        {
            b_PersonEmpty = true;
            CompareCorrectSeat();
        }
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

    //public void onSelectedSeat()
    //{
    //    switch (seatIndex)
    //    {
    //        case 0:
    //            // 카르센사 대표님 그 자리에 앉히기
    //            // - 부장님 자세 애니메이션으로 바꾸기
    //            // - 부장님 위치 의자 위로 변경
    //            // - 부장님 머리 위 정팔면체 없애기
    //            // - 앉은 의자 선택 시 색 변경하는거 없애기
    //            // - 앉은 의자 위 원뿔 없애기

    //            break;
    //        case 1:
    //            // 카르센사 대리님 그 자리에 앉히기

    //            break;
    //        case 2:
    //            // 카르센사 사원님 그 자리에 앉히기

    //            break;
    //        case 3:
    //            // 박님 그 자리에 앉히기

    //            break;
    //        case 4:
    //            // 정님 그 자리에 앉히기

    //            break;
    //    }
    //}

    public void ChangeCurrentPersonIndex()
    {
        currentPersonIndex++;
    }

    public void GetChairName(string name)
    {
        if (currentPersonIndex >= 0 && currentPersonIndex < arr_chairName.Length)
            arr_chairName[currentPersonIndex] = name;
    }

    void CompareCorrectSeat()
    {
        //for(int i =0; i < 5; i++)
        //{
        //    arr_chairName[i]
        //}

        bool isContainedInArray = IsArrayContainedIn(arr_answerSeat, arr_chairName);
        if (isContainedInArray)
        {
            ScoreMng.main.addScore(100, "Chapter5");
        }

        ChangeScene();
    }

    public static bool IsArrayContainedIn(string[] sourceArray, string[] targetArray)
    {
        return !sourceArray.Except(targetArray).Any();
    }

    // 씬 전환
    void ChangeScene()
    {
        //Debug.Log("씬 전환");
        SceneManager.LoadScene("Chapter6");
    }
}
