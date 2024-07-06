using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using InputDevice = UnityEngine.XR.InputDevice;
public class InputManager : MonoBehaviour
{
    public static InputManager instance { get; private set; }
    public InputDevice _rightController;
    public InputDevice _leftController;
    public XRBaseController RightController;

    private bool previousButtonState = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        InitInputDevices();
    }
    
    private void InitInputDevices()
    {
        InitInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, ref _rightController);
        InitInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref _leftController);
    }

    private void InitInputDevice(InputDeviceCharacteristics inputCharacteristics, ref InputDevice inputDevice)
    {
        if (inputDevice.isValid)
            return;

        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(inputCharacteristics, devices);
        if (devices.Count > 0)
        {
            inputDevice = devices[0];
        }
    }

    /*
    CommonUsages.triggerButton ==> 트리거 버튼
    CommonUsages.gripButton ==> 그립 버튼
    CommonUsages.primaryButton ==> 각 컨트롤러의 아래 버튼(ex) a버튼)
    CommonUsages.secondaryButton ==>각 컨트롤러의 위에 버튼(ex) b버튼)
    */
    public bool GetDeviceBtn(InputDevice device, InputFeatureUsage<bool> button)
    {
        InitInputDevices();

        if (device.TryGetFeatureValue(button, out bool isBtnClicked))
        {
            return isBtnClicked;
        }

        return false;
    }
}