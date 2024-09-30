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
        ++ScoreManager.Instance.Score;
    }
}
