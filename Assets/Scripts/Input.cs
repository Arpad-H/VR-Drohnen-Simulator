using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.iOS;
using UnityEngine.XR;
using InputDevice = UnityEngine.XR.InputDevice;


[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(InputData))]
public class Input : MonoBehaviour
{

    private InputData inputData;
    private Vector2 throttleStick;
    private Vector2 pitchStick;

    public Vector2 PitchStick
    {
        get => pitchStick;
        set => pitchStick = value;
    }

    public Vector2 ThrottleStick
    {
        get => throttleStick;
        set => throttleStick = value;
    }


    private void Start()
    {
        inputData = GetComponent<InputData>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (inputData.leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out throttleStick))
        {
            Debug.Log(throttleStick);
        }
        if (inputData.rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out pitchStick))
        {
            Debug.Log(pitchStick);
        }
        
    }

    // private void OnRotateAnchor(InputValue value)
    // {
    //     stick = value.Get<Vector2>();
    // }

   
}
