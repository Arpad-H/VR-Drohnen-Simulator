using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Base_RigidBody : MonoBehaviour
{
    [Header("RigidBodyProperties")] 
    [SerializeField] private float weightinKg = 0.6f;

    [SerializeField] protected float startDrag;
    [SerializeField] protected float startAngularDrag;
    
    protected Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.mass = weightinKg;
            startDrag = rb.drag;
            startAngularDrag = rb.angularDrag;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rb)
        {
            return;
        }

        HandlePhysics();
    }

    protected virtual void HandlePhysics()
    {
        
    }
}
