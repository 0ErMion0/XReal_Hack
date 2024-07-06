using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class SelectCloth : MonoBehaviour
{
    [SerializeField] GameObject closetButtons;
    [SerializeField] GameObject textImg;
    [SerializeField] GameObject idCard;
    
    public Image displayTop;
    public Image displayAccessory;
    public Image displayPants;
    public Image displayShoes;

    public Sprite[] arg_tops;
    public Sprite[] arg_accessory;
    public Sprite[] arg_pants;
    public Sprite[] arg_shoes;

    int[] scoreTops = { 10, 25 };
    int[] scoreAccessorys = { 0,25,10};
    int[] scorePants = { 10, 25 };
    int[] scoreShoes = {0,25};


    // 선택된 UI 인덱스
    int currentTopIndex = 0;
    int currentAccessoryIndex = 0;
    int currentPantsIndex = 0;
    int currentShoesIndex = 0;

    // 대사
    public TMP_Text tmp;
    private int speechIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        closetButtons.SetActive(false);
        idCard.SetActive(false);
        //idCard.GetComponent<XRGrabInteractable>().enabled = true;

        // 대사 시작
        Speech();

       //UpdateDisplay();
    }

    // 대사
    void Speech()
    {
        textImg.SetActive(true);
        switch (speechIndex)
        {
            case 0:
                tmp.text = "오늘은 어떻게 입을까?"; // <- 이거로 변경하기

                //SoundManager._instance.PlaySound(Define.ch2RunningFootVfx); // 변경 필요 test 용
                ////StartCoroutine(WaitForSpeech(Define.ch2RunningFootVfx));

                //AudioClip clip = Resources.Load<AudioClip>(Define.ch2RunningFootVfx);
                //StartCoroutine(WaitForSpeech(clip));

                SoundManager._instance.PlaySoundCor(Define.ch1Conversation_1, OnSpeechComplete0);
                //OnSpeechComplete0();

                speechIndex++;

                //// 옷 고르기 ui 버튼 활성화 및 자막 비활성화
                //closetButtons.SetActive(true);
                //textImg.SetActive(false);
                break;
            case 1:
                tmp.text = "아차차! 사원증 챙겨야지";
                SoundManager._instance.PlaySoundCor(Define.ch1Conversation_2, OnSpeechComplete1);
                speechIndex = 0;

                // 사원증 활성화

                break;
        }
    }

    //private IEnumerator WaitForSpeech(string path)
    //{
    //    SoundManager._instance.PlaySound(path);

    //    AudioClip clip = Resources.Load<AudioClip>(Define.soundRoot + "/" + path);

    //    yield return new WaitForSeconds(clip.length);
    //    Debug.Log(clip.length);
    //    //// 옷 고르기 ui 버튼 활성화 및 자막 비활성화
    //    //closetButtons.SetActive(true);
    //    //textImg.SetActive(false);
    //}

    void OnSpeechComplete0()
    {
        UpdateDisplay();

        // 옷 고르기 ui 버튼 활성화 및 자막 비활성화
        closetButtons.SetActive(true);
        textImg.SetActive(false);
    }

    void OnSpeechComplete1()
    {
        // 자막 비활성화 & 사원증 그랩 활성화
        textImg.SetActive(false);
        idCard.SetActive(true);
        //idCard.GetComponent<XRGrabInteractable>().enabled = true;
    }

    private void UpdateDisplay()
    {
        //if(arg_tops.Length > 0)
        //{
        displayTop.sprite = arg_tops[currentTopIndex];
        displayAccessory.sprite = arg_accessory[currentAccessoryIndex];
        displayPants.sprite = arg_pants[currentPantsIndex];
        displayShoes.sprite = arg_shoes[currentShoesIndex];
        //}
    }

    // 상의 변경 버튼
    public void OnClickShowPreviousTop()
    {
        //Debug.Log("버튼 클릭");
        SoundManager._instance.PlaySound(Define.ch1ClothSweepVfx);
        currentTopIndex--;
        if(currentTopIndex < 0)
        {
            currentTopIndex = arg_tops.Length - 1;
        }
        UpdateDisplay();
    }

    public void OnClickShowNextTop()
    {
        SoundManager._instance.PlaySound(Define.ch1ClothSweepVfx);
        currentTopIndex++;
        if (currentTopIndex >= arg_tops.Length)
        {
            currentTopIndex = 0;
        }
        UpdateDisplay();
    }

    // 악세사리 변경 버튼
    public void OnClickShowPreviousAccessory()
    {
        SoundManager._instance.PlaySound(Define.ch1ClothFootstepVfx);
        currentAccessoryIndex--;
        if (currentAccessoryIndex < 0)
        {
            currentAccessoryIndex = arg_accessory.Length - 1;
        }
        UpdateDisplay();
    }

    public void OnClickShowNextAccessory()
    {
        SoundManager._instance.PlaySound(Define.ch1ClothFootstepVfx);
        currentAccessoryIndex++;
        if (currentAccessoryIndex >= arg_accessory.Length)
        {
            currentAccessoryIndex = 0;
        }
        UpdateDisplay();
    }

    //void OnButtonClicked(Button clickedButton)
    //{
    //    // 이전에 선택된 버튼의 선택 해제
    //    if (selectedButton != null)
    //    {
    //        DeselectButton(selectedButton);
    //    }

    //    // 현재 클릭된 버튼을 선택 상태로 설정
    //    SelectButton(clickedButton);
    //}
    //void SelectButton(Button button)
    //{
    //    selectedButton = button;

    //    //currentAccessoryIndex = button.

    //    //// 선택된 버튼의 시각적 피드백을 주기 위해 색상 변경 (예시)
    //    //ColorBlock colors = button.colors;
    //    //colors.normalColor = Color.green;
    //    //button.colors = colors;
    //}

    //void DeselectButton(Button button)
    //{

    //    //// 선택 해제된 버튼의 시각적 피드백을 원래대로 변경 (예시)
    //    //ColorBlock colors = button.colors;
    //    //colors.normalColor = Color.white;
    //    //button.colors = colors;
    //}

    // 하의 변경 버튼
    public void OnClickShowPreviousPants()
    {
        SoundManager._instance.PlaySound(Define.ch1ClothSweepVfx);
        currentPantsIndex--;
        if (currentPantsIndex < 0)
        {
            currentPantsIndex = arg_pants.Length - 1;
        }
        UpdateDisplay();
    }

    public void OnClickShowNextPants()
    {
        SoundManager._instance.PlaySound(Define.ch1ClothSweepVfx);
        currentPantsIndex++;
        if (currentPantsIndex >= arg_pants.Length)
        {
            currentPantsIndex = 0;
        }
        UpdateDisplay();
    }


    // 신발 변경 버튼
    public void OnClickShowPreviousShoes()
    {
        SoundManager._instance.PlaySound(Define.ch1ClothFootstepVfx);
        currentShoesIndex--;
        if (currentShoesIndex < 0)
        {
            currentShoesIndex = arg_shoes.Length - 1;
        }
        UpdateDisplay();
    }

    public void OnClickShowNextShoes()
    {
        SoundManager._instance.PlaySound(Define.ch1ClothFootstepVfx);
        currentShoesIndex++;
        if (currentShoesIndex >= arg_shoes.Length)
        {
            currentShoesIndex = 0;
        }
        UpdateDisplay();
    }

    // 완료 버튼
    // - ui button 사라지고
    // - 대사 출력
    public void OnClickSelectFinish()
    {
        // UI 버튼 비활성화, 대사 활성화
        closetButtons.SetActive(false);
        textImg.SetActive(true);

        // 점수 넘기기
        ScoreMng.main.addScore(scoreTops[currentTopIndex], "Chapter1");
        ScoreMng.main.addScore(scoreAccessorys[currentAccessoryIndex], "Chapter1");
        ScoreMng.main.addScore(scorePants[currentPantsIndex], "Chapter1");
        ScoreMng.main.addScore(scoreShoes[currentShoesIndex], "Chapter1");

        Speech();
    }

    // 사원증 그랩
    public void OnGrabIDCard()
    {
        Invoke(nameof(ChangeScene), 1f);
    }

    // 씬 전환
    void ChangeScene()
    {
        //Debug.Log("씬 전환");
        SceneManager.LoadScene("Chapter3");
    }
}
