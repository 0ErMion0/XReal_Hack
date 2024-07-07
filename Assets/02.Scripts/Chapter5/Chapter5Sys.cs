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

    // ���
    [SerializeField] GameObject textImg;
    public TMP_Text tmp;
    private int speechIndex = 0;

    // �ڸ� ����
    public int currentPersonIndex;
    int seatIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        textImg.SetActive(true);

        // ��
        SoundManager._instance.PlaySoundCor(Define.ch5KnockingVfx, OnSpeechComplete0);

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

    public void onSelectedSeat()
    {
        switch (seatIndex)
        {
            case 0:
                // ī������ ��ǥ�� �� �ڸ��� ������
                // - ����� �ڼ� �ִϸ��̼����� �ٲٱ�
                // - ����� ��ġ ���� ���� ����
                // - ����� �Ӹ� �� ���ȸ�ü ���ֱ�
                // - ���� ���� ���� �� �� �����ϴ°� ���ֱ�
                // - ���� ���� �� ���� ���ֱ�

                break;
            case 1:
                // ī������ �븮�� �� �ڸ��� ������

                break;
            case 2:
                // ī������ ����� �� �ڸ��� ������

                break;
            case 3:
                // �ڴ� �� �ڸ��� ������

                break;
            case 4:
                // ���� �� �ڸ��� ������

                break;
        }
    }

    public void changeCurrentPersonIndex()
    {
        currentPersonIndex++;
    }

}
