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
        ++ScoreManager.Instance.Score;
    }
}
