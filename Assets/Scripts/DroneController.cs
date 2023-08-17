using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DroneController : Base_RigidBody
{
    [Header("Control Properties")] [SerializeField]
    private float minMaxPitch = 30f;

    [SerializeField] private float minMaxRoll = 30f;
    [SerializeField] private float minMaxYaw = 4f;
    private float finalPitch;
    private float finalRoll;
    private float finalYaw;
    private float yaw;
    [SerializeField]private float lerpSpeed = 2f;

    private Input input;
    private List<IEngine> engines = new List<IEngine>();
    private void Start()
    {
        input = GetComponent<Input>();
        engines = GetComponentsInChildren<IEngine>().ToList<IEngine>();
    }

    protected override void HandlePhysics()
    {
        HandleEngines();
        HandleControlls();
        // HandleProp();
    }

    protected virtual void HandleEngines()
    {
        //rb.AddForce(Vector3.up* (rb.mass *Physics.gravity.magnitude));
        foreach (IEngine engine in engines)
        {
            engine.UpdateEngine(rb, input);
        }
    }
    // protected virtual void HandleProp()
    // {
    //     //rb.AddForce(Vector3.up* (rb.mass *Physics.gravity.magnitude));
    //     foreach (IEngine engine in engines)
    //     {
    //         engine.UpdateProp(rb);
    //     }
    // }

    protected virtual void HandleControlls()
    {
        float pitch = input.PitchStick.y * minMaxPitch;
        float roll = -input.PitchStick.x * minMaxRoll;
         yaw += input.ThrottleStick.x * minMaxYaw;

         //smooth out controlls
        finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
        finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
        finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);
        
        Quaternion rotation = Quaternion.Euler(finalPitch,finalYaw, finalRoll);
        rb.MoveRotation(rotation);
    }
}