using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chapter2Sys : MonoBehaviour
{
    public static Chapter2Sys instance { get; private set; }
    [SerializeField] private Animator alevatorAnim;
    public bool isClear;
    public bool isTriggerEnter;
    [SerializeField] private GameObject directorObj;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private float duration = 5.0f;
    [SerializeField] private Transform clearPosition;
    [SerializeField] public List<Collider> btnCols;
    [SerializeField] private Animator bojangAnim;
    [SerializeField] private Transform playerPos;

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
        StartCoroutine(MoveObject(directorObj.transform, targetPosition.position, duration, ClearChapter2Scene));
    }

    private IEnumerator MoveObject(Transform objectTransform, Vector3 target, float duration, System.Action onComplete)
    {
        // 시작 위치 저장
        Vector3 startPosition = objectTransform.position;
        // 초기 y 좌표 저장
        float initialY = startPosition.y;

        // 경과 시간 초기화
        float elapsedTime = 0f;
        bojangAnim.SetBool("Run", true);

        while (elapsedTime < duration)
        {
            // 경과 시간 업데이트
            elapsedTime += Time.deltaTime;
            // 보간 비율 계산
            float t = elapsedTime / duration;

            // x와 z 좌표 보간, y는 고정
            float newX = Mathf.Lerp(startPosition.x, target.x, t);
            float newZ = Mathf.Lerp(startPosition.z, target.z, t);

            // 새로운 위치 설정
            Vector3 newPosition = new Vector3(newX, initialY, newZ);
            objectTransform.position = newPosition;

            // 목표 위치 바라보기
            objectTransform.LookAt(new Vector3(target.x, initialY, target.z));

            // 다음 프레임까지 대기
            yield return null;
        }

        // 최종 위치 설정
        objectTransform.position = new Vector3(target.x, initialY, target.z);
        // 완료 콜백 호출
        onComplete?.Invoke();
    }

    private void ClearChapter2Scene()
    {
        SoundManager._instance.PlaySound(Define.doorClose);
        if (isTriggerEnter&&isClear)
        {
            bojangAnim.SetBool("Run",false);
            bojangAnim.SetBool("Walk",true);
            StartCoroutine(MoveObject(directorObj.transform, clearPosition.position, 1.0f, EndPointReached));
            EndScene();
            //스코어 100
            // 점수 넘기기
            ScoreMng.main.addScore(100, "Chapter3");

            // 씬 전환
            Invoke(nameof(ChangeScene), 3f);
        }
        else if(isTriggerEnter&&!isClear)
        {
            bojangAnim.SetBool("Run",false);
            bojangAnim.SetBool("Angry",true);
            Debug.Log("Chapter 2 is not clear.");
            EndScene();
            //스코어 0

            // 씬 전환
            Invoke(nameof(ChangeScene), 3f);
        }
        else if (!isTriggerEnter)
        {
            bojangAnim.SetBool("Run",false);
            bojangAnim.SetBool("Angry",true);
            Debug.Log("아무것도 안함");
            EndScene();
            //스코어 50
            ScoreMng.main.addScore(50, "Chapter3");

            // 씬 전환
            Invoke(nameof(ChangeScene), 3f);
        }
        // 씬 전환
        //Invoke(nameof(ChangeScene), 3f);
    }
    public void EndScene()
    {
        foreach (var collider in btnCols)
        {
            collider.enabled = false;
        }
    }
    private void EndPointReached()
    {
        SoundManager._instance.PlaySound(Define.correctSound);
        bojangAnim.SetBool("LastIdle", true);
        directorObj.transform.LookAt(playerPos);

        // 씬 전환
        Invoke(nameof(ChangeScene), 3f);
    }

    // 씬 전환
    void ChangeScene()
    {
        SceneManager.LoadScene("Chapter4");
    }
}
