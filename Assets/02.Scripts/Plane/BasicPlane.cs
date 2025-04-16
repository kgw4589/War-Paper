using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlane : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float rotXValue = 25;
    [SerializeField] private float rotZValue = 25;
    
    [SerializeField] private float rotLerpValue = 2;
    
    [SerializeField] protected float moveSpeed = 3000;
    
    protected float RotXValue = 0;
    protected float RotZValue = 0;

    private Vector3 _rotateValue;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveAirPlane();
    }
    
    private void MoveAirPlane()
    {
        Vector3 lerpVector = new Vector3(-RotXValue * rotXValue, 0 ,-RotZValue * rotZValue);  
        _rotateValue = Vector3.Lerp(_rotateValue, lerpVector, rotLerpValue * Time.fixedDeltaTime);
        
        _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(_rotateValue * Time.fixedDeltaTime));
        
        _rigidbody.velocity = transform.forward * (moveSpeed * Time.fixedDeltaTime);
    }
}
