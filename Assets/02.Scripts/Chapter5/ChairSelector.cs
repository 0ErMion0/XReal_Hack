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

    // ���� ������Ʈ�� ���õǾ��� �� ȣ��� �޼���
    public void OnChairSelected()
    {
        //if (currentPplIndex < 4)
        {
            // ����
            Debug.Log(chairSO.ChairName);
            Chapter5Sys.instance5.GetChairName(chairSO.ChairName);

            // ���õ� ���� ������Ʈ�� ��ġ ��������
            Vector3 chairPosition = transform.position;
            // ��� ������Ʈ�� ��ġ�� ���� ������Ʈ ���� ����
            Vector3 personPosition = chairPosition + Vector3.up * -1.0f; // ���� ���� ��� ��ġ
            pplObjs[currentPplIndex].transform.position = personPosition;

            // ��� �ε��� ����
            Chapter5Sys.instance5.ChangeCurrentPersonIndex();

            // ���� �Ұ���� ����
            gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            headObj.SetActive(false);
        }
    }
}
