using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamagable
{
    // 필요 속성 : 이동 속도
    public float speed = 5f;

    private void Update()
    {
        // 2. 이동하고 싶다. P = P0 + vt
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            ScoreManager.Instance.Score += 1;
        }
    }

    public void DamageAction()
    {
        ObjectPoolManager.Instance.ReturnBullet(gameObject);
    }
}
