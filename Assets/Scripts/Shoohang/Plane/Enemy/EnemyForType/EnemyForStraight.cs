using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForStraight : BasicEnemy
{
    protected override void EnableLogic()
    {
        
    }

    public override void DamageAction()
    {
        ObjectPoolManager.Instance.SpawnExplosion(transform.position);
        ++ScoreManager.Instance.Score;
        ObjectPoolManager.Instance.ReturnEnemy((int)myEnemyType, gameObject);
    }
}
