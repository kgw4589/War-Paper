using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamagable
{
    public enum BulletType
    {
        Player,
        Enemy
    }

    public BulletType myBulletType;
    
    // 필요 속성 : 이동 속도
    public float speed = 3000f;

    private void Update()
    {
        // 2. 이동하고 싶다. P = P0 + vt
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        ObjectPoolManager.Instance.StartExplosion(transform.position);
        
        switch (myBulletType)
        {
            case BulletType.Player :
                if (other.gameObject.CompareTag("Enemy"))
                {
                    ScoreManager.Instance.Score += 1;
                }
                ObjectPoolManager.Instance.ReturnBullet(gameObject);
                break;
            
            case BulletType.Enemy :
                if (other.gameObject.CompareTag("Player"))
                {
                }
                ObjectPoolManager.Instance.ReturnEnemyBullet(gameObject);
                break;
        }
    }

    public void DamageAction()
    {
        
    }
}
