using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputData : MonoBehaviour
{
    public InputDevice rightController;
    public InputDevice leftController;
    public InputDevice hmd;


    // Update is called once per frame
    void Update()
    {
        if (!rightController.isValid || !leftController.isValid || !hmd.isValid)
        {
            InitialzeInputDevices();
        }
    }

    private void InitialzeInputDevices()
    {
        if (!rightController.isValid)
        {
            InitialzeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right,
                ref rightController);
        }

        if (!leftController.isValid)
        {
            InitialzeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left,
                ref leftController);
        }

        if (!hmd.isValid)
        {
            InitialzeInputDevice(InputDeviceCharacteristics.HeadMounted, ref hmd);
        }
    }

    private void InitialzeInputDevice(InputDeviceCharacteristics inputCharacteristics, ref InputDevice inputDevice)
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(inputCharacteristics, devices);

        if (devices.Count > 0)
        {
            inputDevice = devices[0];
        }
    }
}