using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BasicPlane, IDamagable
{
    private float _rotXAmount = 7.5f;
    private float _rotZAmount = 7.5f;

    private void Update()
    {
        RotXValue = Input.GetAxis("Mouse Y") * _rotXAmount;
        RotZValue = Input.GetAxis("Mouse X") * _rotZAmount;
        
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = ObjectPoolManager.Instance.GetBullet();

            if (bullet)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
            }
        }
    }

    public void DamageAction()
    {
        
    }
}
