using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BasicPlane, IDamagable
{
    [SerializeField] private Transform firePosition;
    
    private float _rotXAmount = 7.5f;
    private float _rotZAmount = 7.5f;

    private float _currentFireTime = 0.0f;
    private float _fireDelay = 0.25f;

    private void Update()
    {
        RotXValue = Input.GetAxis("Mouse Y") * _rotXAmount;
        RotZValue = Input.GetAxis("Mouse X") * _rotZAmount;
        
        Fire();
    }

    private void Fire()
    {
        _currentFireTime += Time.deltaTime;

        if (_currentFireTime < _fireDelay)
        {
            return;
        }
        
        if (Input.GetButton("Fire1"))
        {
            GameObject bullet = ObjectPoolManager.Instance.GetBullet();

            bullet.transform.position = firePosition.position;
            bullet.transform.rotation = firePosition.rotation;

            _currentFireTime = 0;
        }
    }

    public void DamageAction()
    {
        
    }
}
