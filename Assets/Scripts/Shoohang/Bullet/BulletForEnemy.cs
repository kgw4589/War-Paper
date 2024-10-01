using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForEnemy : BasicBullet
{
    protected override void EnableLogic()
    {
        GameManager.Instance.ultimateAction += DamageAction;
    }

    private void OnDisable()
    {
        GameManager.Instance.ultimateAction -= DamageAction;
    }

    public override void DamageAction()
    {
        ObjectPoolManager.Instance.SpawnExplosion(transform.position);
        ObjectPoolManager.Instance.ReturnEnemyBullet(gameObject);
    }
}
