using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForTraking : BasicEnemy
{
    protected override void EnableLogic()
    {
        
    }

    private void Update()
    {
        transform.LookAt(Target?.transform);
    }

    public override void DamageAction()
    {
        ObjectPoolManager.Instance.SpawnExplosion(transform.position);
        ++ScoreManager.Instance.Score;
        ObjectPoolManager.Instance.ReturnEnemy((int)myEnemyType, gameObject);
    }
}
