using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class BasicEnemy : BasicPlane, IDamagable
{
    public enum EnemyType
    {
        Straight = 0,
        Tracking = 1,
        Fire = 2
    }

    public EnemyType myEnemyType;
    
    protected GameObject Target;

    [SerializeField] private float shihanbooTime = 45f;

    [SerializeField] protected int upScoreValue = 1;
    
    private void OnEnable()
    {
        StartCoroutine(InitEnemy());
    }
    
    private IEnumerator InitEnemy()
    {
        yield return new WaitUntil(() => GameManager.Instance.player is not null);
        
        Target = GameManager.Instance.player;
        Debug.Log(Target);
        transform.forward = Target.transform.position - transform.position;

        StartCoroutine(Shihanboo());
        EnableLogic();
    }

    protected abstract void EnableLogic();
    
    private IEnumerator Shihanboo()
    {
        yield return new WaitForSeconds(shihanbooTime);
        
        gameObject.SetActive(false);
        ObjectPoolManager.Instance.ReturnEnemy((int)myEnemyType, gameObject);
    }
    
    protected virtual void OnCollisionEnter(Collision other)
    {
        IDamagable damageAction = other.gameObject.GetComponent<IDamagable>();

        if (damageAction is not null)
        {
            damageAction.DamageAction();

            if (Random.Range(0, 100) < 100)
            {
                ObjectPoolManager.Instance.SpawnItem(transform.position);
            }
            
            return;
        }

        DamageAction();
        ScoreManager.Instance.Score -= upScoreValue;
    }

    public abstract void DamageAction();
}
