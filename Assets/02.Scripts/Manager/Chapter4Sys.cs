using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chapter4Sys : MonoBehaviour
{
    public static Chapter4Sys instance { get; private set; }
    public bool isClear;
    public string clearOrder;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(WaitAndPerform(5.8f, 15.0f));
    }

    private IEnumerator WaitAndPerform(float initialWait, float taskDuration)
    {
        SoundManager._instance.PlaySound(Define.ch4Conversation_1);
        yield return new WaitForSeconds(initialWait);

        float elapsedTime = 0f;
        while (elapsedTime < taskDuration)
        {
            // 경과 시간 업데이트
            elapsedTime += Time.deltaTime;

            // 다음 프레임까지 대기
            yield return null;
        }

        CheckChapter4Scnene();
        Debug.Log("15초 경과 완료");
    }
    private void CheckChapter4Scnene()
    {
        if (clearOrder == "123")
        {
            ScoreMng.main.addScore(100,"Chapter4");
        }
        SceneManager.LoadScene("Chapter6");

    }
}
