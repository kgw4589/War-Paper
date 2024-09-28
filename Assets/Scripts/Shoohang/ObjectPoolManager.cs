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

    private GameObject _enemyFactory;
    private int _enemyPoolSize = 100;
    private List<GameObject> _enemyPool;

    private GameObject _enemyBulletFactory;
    private int _enemyBulletPoolSize = 100;
    private List<GameObject> _enemyBulletPool;

    protected override void Init()
    {
        _bulletFactory = Resources.Load<GameObject>("Player Bullet");
        _enemyFactory = Resources.Load<GameObject>("Enemy");
        _explosionFactory = Resources.Load<GameObject>("Explosion");
        _enemyBulletFactory = Resources.Load<GameObject>("Enemy Bullet");
        
        SetBulletPool();
        SetEnemyPool(); 
        SetExplosionPool();
        SetEnemyBulletPool();
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
    private void SetEnemyPool()
    {
        _enemyPool = new List<GameObject>();
        
        for (int i = 0; i < _enemyPoolSize; i++)
        {
            GameObject explosion = Instantiate(_enemyFactory, transform);
            
            _enemyPool.Add(explosion);
            
            explosion.SetActive(false);
        }
    }
    
    private void SetExplosionPool()
    {
        _explosionPool = new List<GameObject>();
        
        for (int i = 0; i < _explosionPoolSize; i++)
        {
            GameObject enemy = Instantiate(_explosionFactory, transform);
            
            _explosionPool.Add(enemy);
            
            enemy.SetActive(false);
        }
    }

    private void SetEnemyBulletPool()
    {
        _enemyBulletPool = new List<GameObject>();
        
        for (int i = 0; i < _enemyBulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(_enemyBulletFactory, transform);
            
            _enemyBulletPool.Add(bullet);
            
            bullet.SetActive(false);
        }
    }
    
    public GameObject GetBullet()
    {
        GameObject bullet = null;
        
        if (_bulletPool.Count > 0)
        {
            bullet = _bulletPool[0];
            _bulletPool.Remove(bullet);
        }
        else
        {
            bullet = Instantiate(_bulletFactory, transform);
        }

        bullet.SetActive(true);

        return bullet;
    }
    
    public GameObject GetEnemy()
    {
        GameObject enemy = null;
        
        if (_enemyPool.Count > 0)
        {
            enemy = _enemyPool[0];
            _enemyPool.Remove(enemy);
        }
        else
        {
            enemy = Instantiate(_enemyFactory, transform);
        }

        enemy.SetActive(true);
        
        return enemy;
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
    
    public GameObject GetEnemyBullet()
    {
        GameObject bullet = null;
        
        if (_enemyPool.Count > 0)
        {
            bullet = _enemyPool[0];
            _enemyPool.Remove(bullet);
        }
        else
        {
            bullet = Instantiate(_enemyBulletFactory, transform);
        }

        bullet.SetActive(true);

        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        _bulletPool.Add(bullet);
    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        _enemyPool.Add(enemy);
    }
    
    public void ReturnEnemyBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        _enemyBulletPool.Add(bullet);
    }
}
