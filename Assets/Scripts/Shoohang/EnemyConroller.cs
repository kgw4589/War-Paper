using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConroller : BasicPlane
{
    private GameObject _target;
    
    private void Start()
    {
        _target = GameManager.Instance.player;
    }
    
    private void Update()
    {
        transform.LookAt(_target.transform);
    }

    private void OnCollisionEnter(Collision other)
    {
        // ScoreManager.Instance.Score++;
        
        ObjectPoolManager.Instance.StartExplosion(transform.position);

        IDamagable damageAction = other.gameObject.GetComponent<IDamagable>();
        if (damageAction is not null)
        {
            damageAction.DamageAction();
        }
        
        gameObject.SetActive(false);
    }
}
