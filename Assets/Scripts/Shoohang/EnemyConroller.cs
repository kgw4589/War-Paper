using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyConroller : BasicPlane
{
    private enum EnemyType
    {
        Straight,
        Tracking,
        BulletFire
    }

    private EnemyType _myType;
    
    private GameObject _target;

    private float _attackDelay = 0;

    private void Start()
    {
        _target = GameManager.Instance.player;

        int randomValue = Random.Range(0, 10);
        
        if (randomValue < 3)
        {
            _myType = EnemyType.Straight;
            transform.forward = _target.transform.position - transform.position;
        }
        else if (randomValue < 5)
        {
            _myType = EnemyType.Tracking;
        }
        else
        {
            _myType = EnemyType.BulletFire;
            moveSpeed = 0f;
            _attackDelay = Random.Range(15, 30);

            StartCoroutine(BulletFireEnemy());
        }
    }
    
    private void Update()
    {
        switch (_myType)
        {
            case EnemyType.Tracking :
                transform.LookAt(_target.transform);
                break;
            
            case EnemyType.BulletFire :
                transform.LookAt(_target.transform);
                break;
        }
    }

    private IEnumerator BulletFireEnemy()
    {
        GameObject bullet = ObjectPoolManager.Instance.GetEnemyBullet();
        bullet.transform.position = transform.position;
        bullet.transform.forward = transform.forward;
        
        yield return new WaitForSeconds(_attackDelay);
        StartCoroutine(BulletFireEnemy());
    }
    
    private void OnCollisionEnter(Collision other)
    {
        ObjectPoolManager.Instance.StartExplosion(transform.position);

        IDamagable damageAction = other.gameObject.GetComponent<IDamagable>();
        if (damageAction is not null)
        {
            damageAction.DamageAction();
        }
        
        gameObject.SetActive(false);
        ObjectPoolManager.Instance.ReturnEnemy(gameObject);
    }
}
