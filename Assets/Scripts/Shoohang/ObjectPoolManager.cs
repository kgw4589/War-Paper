using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    private GameObject _bulletFactory;
    private int _bulletPoolSize = 100;
    private List<GameObject> _bulletPool;

    private GameObject _explosionFactory;
    private int _explosionPoolSize = 100;
    private List<GameObject> _explosionPool;

    protected override void Init()
    {
        _bulletFactory = Resources.Load<GameObject>("Bullet");
        _explosionFactory = Resources.Load<GameObject>("Explosion");
        
        SetBulletPool();
        SetExplosionPool();
    }

    private void SetBulletPool()
    {
        _bulletPool = new List<GameObject>();
        
        for (int i = 0; i < _bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletFactory, transform);
            
            _bulletPool.Add(bullet);
            
            bullet.SetActive(false);
        }
    }
    
    private void SetExplosionPool()
    {
        _explosionPool = new List<GameObject>();
        
        for (int i = 0; i < _explosionPoolSize; i++)
        {
            GameObject explosion = Instantiate(_explosionFactory, transform);
            
            _explosionPool.Add(explosion);
            
            explosion.SetActive(false);
        }
    }

    public GameObject GetBullet()
    {
        if (_bulletPool.Count > 0)
        {
            GameObject bullet = _bulletPool[0];
            bullet.SetActive(true);
            _bulletPool.Remove(bullet);

            return bullet;
        }

        return null;
    }

    public void StartExplosion(Vector3 position) => StartCoroutine(Explosion(position));
    private IEnumerator Explosion(Vector3 position)
    {
        if (_explosionPool.Count > 0)
        {
            GameObject explosion = _explosionPool[0];
            explosion.transform.position = position;
            explosion.SetActive(true);
            _explosionPool.Remove(explosion);
            
            yield return new WaitForSeconds(2.0f);
            
            _explosionPool.Add(explosion);
            explosion.SetActive(false);
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        _bulletPool.Add(bullet);
    }
}
