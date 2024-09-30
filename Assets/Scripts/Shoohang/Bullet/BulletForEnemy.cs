using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForEnemy : BasicBullet
{
    public override void DamageAction()
    {
        ObjectPoolManager.Instance.ReturnEnemyBullet(gameObject);
    }
}
