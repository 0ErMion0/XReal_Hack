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


    // ���õ� UI �ε���
    int currentTopIndex = 0;
    int currentAccessoryIndex = 0;
    int currentPantsIndex = 0;
    int currentShoesIndex = 0;

    // ���
    public TMP_Text tmp;
    private int speechIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        closetButtons.SetActive(false);
        idCard.SetActive(false);
        //idCard.GetComponent<XRGrabInteractable>().enabled = true;

        // ��� ����
        Speech();

       //UpdateDisplay();
    }

    // ���
    void Speech()
    {
        textImg.SetActive(true);
        switch (speechIndex)
        {
            case 0:
                tmp.text = "������ ��� ������?"; // <- �̰ŷ� �����ϱ�

                //SoundManager._instance.PlaySound(Define.ch2RunningFootVfx); // ���� �ʿ� test ��
                ////StartCoroutine(WaitForSpeech(Define.ch2RunningFootVfx));

                //AudioClip clip = Resources.Load<AudioClip>(Define.ch2RunningFootVfx);
                //StartCoroutine(WaitForSpeech(clip));

                SoundManager._instance.PlaySoundCor(Define.ch1Conversation_1, OnSpeechComplete0);
                //OnSpeechComplete0();

                speechIndex++;

                //// �� ���� ui ��ư Ȱ��ȭ �� �ڸ� ��Ȱ��ȭ
                //closetButtons.SetActive(true);
                //textImg.SetActive(false);
                break;
            case 1:
                tmp.text = "������! ����� ì�ܾ���";
                SoundManager._instance.PlaySoundCor(Define.ch1Conversation_2, OnSpeechComplete1);
                speechIndex = 0;

                // ����� Ȱ��ȭ

                break;
        }
    }

    //private IEnumerator WaitForSpeech(string path)
    //{
    //    SoundManager._instance.PlaySound(path);

    //    AudioClip clip = Resources.Load<AudioClip>(Define.soundRoot + "/" + path);

    //    yield return new WaitForSeconds(clip.length);
    //    Debug.Log(clip.length);
    //    //// �� ���� ui ��ư Ȱ��ȭ �� �ڸ� ��Ȱ��ȭ
    //    //closetButtons.SetActive(true);
    //    //textImg.SetActive(false);
    //}

    void OnSpeechComplete0()
    {
        UpdateDisplay();

        // �� ���� ui ��ư Ȱ��ȭ �� �ڸ� ��Ȱ��ȭ
        closetButtons.SetActive(true);
        textImg.SetActive(false);
    }

    void OnSpeechComplete1()
    {
        // �ڸ� ��Ȱ��ȭ & ����� �׷� Ȱ��ȭ
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

    // ���� ���� ��ư
    public void OnClickShowPreviousTop()
    {
        //Debug.Log("��ư Ŭ��");
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

    // �Ǽ��縮 ���� ��ư
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
    //    // ������ ���õ� ��ư�� ���� ����
    //    if (selectedButton != null)
    //    {
    //        DeselectButton(selectedButton);
    //    }

    //    // ���� Ŭ���� ��ư�� ���� ���·� ����
    //    SelectButton(clickedButton);
    //}
    //void SelectButton(Button button)
    //{
    //    selectedButton = button;

    //    //currentAccessoryIndex = button.

    //    //// ���õ� ��ư�� �ð��� �ǵ���� �ֱ� ���� ���� ���� (����)
    //    //ColorBlock colors = button.colors;
    //    //colors.normalColor = Color.green;
    //    //button.colors = colors;
    //}

    //void DeselectButton(Button button)
    //{

    //    //// ���� ������ ��ư�� �ð��� �ǵ���� ������� ���� (����)
    //    //ColorBlock colors = button.colors;
    //    //colors.normalColor = Color.white;
    //    //button.colors = colors;
    //}

    // ���� ���� ��ư
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


    // �Ź� ���� ��ư
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

    // �Ϸ� ��ư
    // - ui button �������
    // - ��� ���
    public void OnClickSelectFinish()
    {
        // UI ��ư ��Ȱ��ȭ, ��� Ȱ��ȭ
        closetButtons.SetActive(false);
        textImg.SetActive(true);

        // ���� �ѱ��
        ScoreMng.main.addScore(scoreTops[currentTopIndex], "Chapter1");
        ScoreMng.main.addScore(scoreAccessorys[currentAccessoryIndex], "Chapter1");
        ScoreMng.main.addScore(scorePants[currentPantsIndex], "Chapter1");
        ScoreMng.main.addScore(scoreShoes[currentShoesIndex], "Chapter1");

        Speech();
    }

    // ����� �׷�
    public void OnGrabIDCard()
    {
        Invoke(nameof(ChangeScene), 1f);
    }

    // �� ��ȯ
    void ChangeScene()
    {
        //Debug.Log("�� ��ȯ");
        SceneManager.LoadScene("Chapter3");
    }
}
