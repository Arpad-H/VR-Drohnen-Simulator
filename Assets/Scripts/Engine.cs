using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Engine : MonoBehaviour, IEngine
{
    [Header("Engine Properties")] [SerializeField]
    private float maxPower = 4f;

    [Header("Propeller Properties")] [SerializeField]
    private float propRotSpeed = 2f;

    [SerializeField]private Transform propeller;
    public void InitEngine()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateEngine(Rigidbody rb , Input input)
    {
        
        //Auto Keep Altitude
        Vector3 upVec = transform.up;
        upVec.x = 0f;
        upVec.z = 0f;
        float diff = 1 - upVec.magnitude;
        float finaldiff = Physics.gravity.magnitude * diff;
        
        
        Vector3 engineForce = Vector3.zero;
        
        //Add final diff to enable auto leveling
        // engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude * -1 + finalDiff) + (input.ThrottleStick.y * maxPower)) /4f;
        engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude * -1) + (input.ThrottleStick.y * maxPower)) /4f;
        rb.AddForce(engineForce, ForceMode.Force);
        
        HandleProp();
    }

    public void HandleProp()
    {
        if (!propeller)
        {
            return;
        }

        propeller.Rotate(Vector3.back,propRotSpeed);
    }
}