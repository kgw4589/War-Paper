using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForFire : BasicEnemy
{
    private float _attackMinDelay = 2.0f;
    private float _attackMaxDelay = 4.0f;
    
    private float _attackDelay = 5f;

    protected override void EnableLogic()
    {
        StartCoroutine(BulletFire());
    }

    private void Update()
    {
        transform.LookAt(Target?.transform);
    }
    
    private IEnumerator BulletFire()
    {
        yield return new WaitForSeconds(_attackDelay);
        _attackDelay = Random.Range(_attackMinDelay, _attackMaxDelay);
        
        GameObject bullet = ObjectPoolManager.Instance.GetEnemyBullet();
        bullet.transform.position = transform.position;
        bullet.transform.forward = transform.forward;
        
        StartCoroutine(BulletFire());
    }

    public override void DamageAction()
    {
        ++ScoreManager.Instance.Score;
    }
}
