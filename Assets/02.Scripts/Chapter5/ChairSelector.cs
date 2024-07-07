using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ChairSelector : MonoBehaviour
{
    public GameObject[] pplObjs;
    private int currentPplIndex;

    public GameObject headObj;

    // Start is called before the first frame update
    void Start()
    {
        headObj.SetActive(true);
        gameObject.GetComponent<XRGrabInteractable>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentPplIndex = Chapter5Sys.instance5.currentPersonIndex;
    }

    // 의자 오브젝트가 선택되었을 때 호출될 메서드
    public void OnChairSelected()
    {
        if (currentPplIndex >= 0)
        {
            // 선택된 의자 오브젝트의 위치 가져오기
            Vector3 chairPosition = transform.position;
            // 사람 오브젝트의 위치를 의자 오브젝트 위로 설정
            Vector3 personPosition = chairPosition + Vector3.up * -1.0f; // 의자 위에 사람 배치
            pplObjs[currentPplIndex].transform.position = personPosition;

            // 사람 인덱스 증가
            Chapter5Sys.instance5.changeCurrentPersonIndex();

            // 선택 불가토록 막기
            gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            headObj.SetActive(false);
        }
        else
        {
            Debug.Log("모든 구 오브젝트가 이미 배치되었습니다.");
        }
    }
}
