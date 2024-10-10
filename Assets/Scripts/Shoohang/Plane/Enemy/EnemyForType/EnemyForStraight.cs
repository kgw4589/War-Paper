using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForStraight : BasicEnemy
{
    protected override void EnableLogic()
    {
        Vector3 moveDirection = Target.transform.position - transform.position;
        moveDirection = moveDirection.normalized;
        
        transform.forward = moveDirection;
    }
}
