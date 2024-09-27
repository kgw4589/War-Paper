using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlane : MonoBehaviour
{
    protected Rigidbody Rigidbody;

    [SerializeField] private float rotXValue = 100;
    [SerializeField] private float rotZValue = 100;
    
    [SerializeField] private float rotLerpValue = 4;
    
    [SerializeField] private float moveSpeed = 100;
    
    protected float RotXValue = 0;
    protected float RotZValue = 0;

    private Vector3 _rotateValue;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveAirPlane();
    }
    
    private void MoveAirPlane()
    {
        Vector3 lerpVector = new Vector3(-RotXValue * rotXValue, 0 ,-RotZValue * rotZValue);  
        _rotateValue = Vector3.Lerp(_rotateValue, lerpVector, rotLerpValue * Time.fixedDeltaTime);
        
        Rigidbody.MoveRotation(Rigidbody.rotation * Quaternion.Euler(_rotateValue * Time.fixedDeltaTime));
        
        Rigidbody.velocity = transform.forward * (moveSpeed * Time.fixedDeltaTime);
    }
}
