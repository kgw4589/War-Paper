using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BasicPlane, IDamagable
{
    [SerializeField] private Transform[] firePositions;

    private float _rotXAmount = 7.5f;
    private float _rotZAmount = 7.5f;

    private float _currentFireTime = 0.0f;
    private float _fireDelay = 0.25f;

    private int _attackLevel = 1;
    private int _speedLevel = 0;
    private float _speedUpValue => moveSpeed * 0.1f;

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
            for (int i = 0; i < _attackLevel; i++)
            {
                GameObject bullet = ObjectPoolManager.Instance.GetBullet();

                bullet.transform.position = firePositions[i].position;
                bullet.transform.rotation = firePositions[i].rotation;
                
                bullet.SetActive(true);
            }

            _currentFireTime = 0;
        }
    }

    public void GetItem(Item.ItemType itemType)
    {
        switch (itemType)
        {
            case Item.ItemType.Attack :
                GetAttackItem();
                break;
            
            case Item.ItemType.Speed :
                GetSpeedItem();
                break;
            
            case Item.ItemType.Ultimate :
                break;
        }
    }

    private void GetAttackItem()
    {
        if (_attackLevel < 7)
        {
            _attackLevel += 2;
        }
    }
    
    private void GetSpeedItem()
    {
        if (_speedLevel++ < 3)
        {
            moveSpeed += _speedUpValue;
            Debug.Log(moveSpeed);
        }
    }
    
    private void GetUltimateItem()
    {
        
    }

    public void DamageAction()
    {
        gameObject.SetActive(false);
    }
}
