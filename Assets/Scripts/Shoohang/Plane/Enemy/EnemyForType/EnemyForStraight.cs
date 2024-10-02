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
        ScoreManager.Instance.Score += upScoreValue;
        ObjectPoolManager.Instance.SpawnExplosion(transform.position);
        ObjectPoolManager.Instance.ReturnEnemy((int)myEnemyType, gameObject);
    }
}
