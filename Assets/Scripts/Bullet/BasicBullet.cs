using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicBullet : MonoBehaviour, IDamagable
{
    public float speed = 3000f;
    public float shihanbooTime = 5f;

    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }
    
    private void OnEnable()
    {
        StartCoroutine(Shihanboo());
        
        EnableLogic();
    }

    private void Update()
    {
        Move();
    }

    private void OnDisable()
    {
        _trailRenderer.Clear();
    }

    protected abstract void EnableLogic();
    
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
        
        DamageAction();
    }
    
    public abstract void DamageAction();
}
