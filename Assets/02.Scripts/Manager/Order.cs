using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
public class Order : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socket;
    [SerializeField] private List<XRSocketInteractor> socketList;
    
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        XRSocketInteractor interactor = args.interactorObject as XRSocketInteractor;
        if (interactor != null)
        {
            Chapter4Sys.instance.clearOrder += interactor.gameObject.name;
        }
    }

}
