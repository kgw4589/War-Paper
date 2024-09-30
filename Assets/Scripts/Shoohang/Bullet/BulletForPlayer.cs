using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForPlayer : BasicBullet
{
    public override void DamageAction()
    {
        ObjectPoolManager.Instance.ReturnBullet(gameObject);
    }
}
