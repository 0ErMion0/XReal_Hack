using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ChairSelector : MonoBehaviour
{
    [SerializeField]
    private ChairSO chairSO;
    public ChairSO ChairSO { set { chairSO = value; } }
    
    public GameObject[] pplObjs;
    private int currentPplIndex = 0;

    public GameObject headObj;

    // Start is called before the first frame update
    void Start()
    {
        headObj.SetActive(true);
        //gameObject.GetComponent<XRGrabInteractable>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentPplIndex = Chapter5Sys.instance5.currentPersonIndex;
    }

    // 의자 오브젝트가 선택되었을 때 호출될 메서드
    public void OnChairSelected()
    {
        //if (currentPplIndex < 4)
        {
            // 의자
            Debug.Log(chairSO.ChairName);
            Chapter5Sys.instance5.GetChairName(chairSO.ChairName);

            // 선택된 의자 오브젝트의 위치 가져오기
            Vector3 chairPosition = transform.position;
            // 사람 오브젝트의 위치를 의자 오브젝트 위로 설정
            Vector3 personPosition = chairPosition + Vector3.up * -1.0f; // 의자 위에 사람 배치
            pplObjs[currentPplIndex].transform.position = personPosition;

            // 사람 인덱스 증가
            Chapter5Sys.instance5.ChangeCurrentPersonIndex();

            // 선택 불가토록 막기
            gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            headObj.SetActive(false);
        }
    }
}
