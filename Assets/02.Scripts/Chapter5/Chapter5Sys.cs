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

    // ���
    [SerializeField] GameObject textImg;
    public TMP_Text tmp;
    private int speechIndex = 0;

    // �ڸ� ����
    public int currentPersonIndex = 0;
    int seatIndex = 0;
    bool b_PersonEmpty = false;

    // ��
    public string[] arr_answerSeat = { "A", "B", "C", "D", "E" };
    public string[] arr_chairName = new string[5];

    // Start is called before the first frame update
    void Start()
    {
        textImg.SetActive(true);

        // �迭 �ʱ�ȭ
        arr_chairName = new string[arr_answerSeat.Length];

        // ��
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

    // ���
    void Speech()
    {
        textImg.SetActive(true);
        switch (speechIndex)
        {
            case 0:
                tmp.text = "Ŭ���̾�Ʈ �е� ���̳�����!";
                SoundManager._instance.PlaySoundCor(Define.ch5Conversation_1, OnSpeechComplete1);
                //speechIndex++;
                break;
            case 1:
                tmp.text = "��� �ɴ°� ������?";
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

        // �ڸ� ���� ����
    }

    //public void onSelectedSeat()
    //{
    //    switch (seatIndex)
    //    {
    //        case 0:
    //            // ī������ ��ǥ�� �� �ڸ��� ������
    //            // - ����� �ڼ� �ִϸ��̼����� �ٲٱ�
    //            // - ����� ��ġ ���� ���� ����
    //            // - ����� �Ӹ� �� ���ȸ�ü ���ֱ�
    //            // - ���� ���� ���� �� �� �����ϴ°� ���ֱ�
    //            // - ���� ���� �� ���� ���ֱ�

    //            break;
    //        case 1:
    //            // ī������ �븮�� �� �ڸ��� ������

    //            break;
    //        case 2:
    //            // ī������ ����� �� �ڸ��� ������

    //            break;
    //        case 3:
    //            // �ڴ� �� �ڸ��� ������

    //            break;
    //        case 4:
    //            // ���� �� �ڸ��� ������

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

    // �� ��ȯ
    void ChangeScene()
    {
        //Debug.Log("�� ��ȯ");
        SceneManager.LoadScene("Chapter6");
    }
}
