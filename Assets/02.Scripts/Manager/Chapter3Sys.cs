using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // 경과 시간 초기화
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // 경과 시간 업데이트
            elapsedTime += Time.deltaTime;
            // 비율 계산
            float t = elapsedTime / duration;
            // Lerp를 사용하여 위치 보간
            objectTransform.position = Vector3.Lerp(startPosition, target, t);
            // 다음 프레임까지 대기
            yield return null;
        }
        objectTransform.position = target;
        
        onComplete?.Invoke();
    }

    private void ClearChapter2Scene()
    {
        if (isTriggerEnter&&isClear)
        {
            StartCoroutine(MoveObject(directorObj.transform, clearPosition.position, 1.0f, null));
            EndScene();
            //스코어 100
        }
        else if(isTriggerEnter&&!isClear)
        {
            Debug.Log("Chapter 2 is not clear.");
            EndScene();
            //스코어 0
        }
        else if (!isTriggerEnter)
        {
            Debug.Log("아무것도 안함");
            EndScene();
            //스코어 50
        }
        
    }
    public void EndScene()
    {
        foreach (var collider in btnCols)
        {
            collider.enabled = false;
        }
    }
}
