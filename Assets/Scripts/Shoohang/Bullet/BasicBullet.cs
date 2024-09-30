using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicBullet : MonoBehaviour, IDamagable
{
    public float speed = 3000f;
    public float shihanbooTime = 5f;

    private void OnEnable()
    {
        StartCoroutine(Shihanboo());
    }

    private void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    private IEnumerator Shihanboo()
    {
        yield return new WaitForSeconds(shihanbooTime);
        DamageAction();
    }

    private void OnCollisionEnter(Collision other)
    {
        ObjectPoolManager.Instance.SpawnExplosion(transform.position);
        
        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();

        if (damagable is not null)
        {
            damagable.DamageAction();
        }
    }
    
    public abstract void DamageAction();
}
