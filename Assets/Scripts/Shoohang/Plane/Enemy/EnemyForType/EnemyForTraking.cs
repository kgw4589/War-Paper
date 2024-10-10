using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForTraking : BasicEnemy
{
    private void Update()
    {
        transform.LookAt(Target?.transform);
    }
}
