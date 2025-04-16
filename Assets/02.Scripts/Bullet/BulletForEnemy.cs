using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForEnemy : BasicBullet
{
    protected override void EnableLogic()
    {
        
    }

    public override void DamageAction()
    {
        ObjectPoolManager.Instance.ReturnEnemyBullet(gameObject);
    }
}
