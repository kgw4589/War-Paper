using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : BasicPlane
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

    private void OnEnable()
    {
        StartCoroutine(InitEnemy());
    }

    private void Update()
    {
        if (_myType != EnemyType.Straight)
        {
            transform.LookAt(_target.transform);
        }
    }

    private IEnumerator InitEnemy()
    {
        yield return new WaitUntil(() => GameManager.Instance.player is not null);
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
            _attackDelay = Random.Range(5, 15);

            StartCoroutine(BulletFireEnemy());
        }

        StartCoroutine(Shihanboo());
    }

    private IEnumerator Shihanboo()
    {
        yield return new WaitForSeconds(45);
        
        gameObject.SetActive(false);
        // ObjectPoolManager.Instance.ReturnEnemy(gameObject);
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
        ObjectPoolManager.Instance.SpawnExplosion(transform.position);

        IDamagable damageAction = other.gameObject.GetComponent<IDamagable>();
        if (damageAction is not null)
        {
            damageAction.DamageAction();
            
            if (Random.Range(0, 100) < 10)
            {
                ObjectPoolManager.Instance.SpawnItem(transform.position);
            }
        }

        gameObject.SetActive(false);
        // ObjectPoolManager.Instance.ReturnEnemy(gameObject);
    }
}
