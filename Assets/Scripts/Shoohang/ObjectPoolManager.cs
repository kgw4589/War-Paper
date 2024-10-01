using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    private GameObject _bulletFactory;
    private int _bulletPoolSize = 1;
    private List<GameObject> _bulletPool;

    private GameObject _explosionFactory;
    private int _explosionPoolSize = 10;
    private List<GameObject> _explosionPool;

    private GameObject[] _enemyFactorys = new GameObject[3];
    private int _enemyPoolSize = 10;
    private List<GameObject>[] _enemyPool = new List<GameObject>[3];

    private GameObject _enemyBulletFactory;
    private int _enemyBulletPoolSize = 10;
    private List<GameObject> _enemyBulletPool;

    private GameObject _itemFactory;
    private int _itemPoolSize = 5;
    private List<GameObject> _itemPool;

    protected override void Init()
    {
        _bulletFactory = Resources.Load<GameObject>("Bullet/Player Bullet");
        _enemyBulletFactory = Resources.Load<GameObject>("Bullet/Enemy Bullet");
        
        _enemyFactorys[(int)BasicEnemy.EnemyType.Straight] = Resources.Load<GameObject>("Enemy/EnemyForStraight");
        _enemyFactorys[(int)BasicEnemy.EnemyType.Tracking] = Resources.Load<GameObject>("Enemy/EnemyForTracking");
        _enemyFactorys[(int)BasicEnemy.EnemyType.Fire] = Resources.Load<GameObject>("Enemy/EnemyForFire");
        
        _explosionFactory = Resources.Load<GameObject>("Explosion");
        _itemFactory = Resources.Load<GameObject>("Item");
        
        SetBulletPool();
        SetEnemyPool(); 
        SetExplosionPool();
        SetEnemyBulletPool();
        SetItemPool();
    }

    private void SetBulletPool()
    {
        _bulletPool = new List<GameObject>();
        
        for (int i = 0; i < _bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletFactory, GameManager.Instance.player.transform);
            
            _bulletPool.Add(bullet);
            
            bullet.SetActive(false);
        }
    }
    private void SetEnemyPool()
    {
        _enemyPool[(int)BasicEnemy.EnemyType.Straight] = new List<GameObject>();
        _enemyPool[(int)BasicEnemy.EnemyType.Tracking] = new List<GameObject>();
        _enemyPool[(int)BasicEnemy.EnemyType.Fire] = new List<GameObject>();
        
        for (int i = 0; i < _enemyPoolSize; i++)
        {
            GameObject straightEnemy = Instantiate(_enemyFactorys[(int)BasicEnemy.EnemyType.Straight], transform);
            GameObject trackingEnemy = Instantiate(_enemyFactorys[(int)BasicEnemy.EnemyType.Tracking], transform);
            GameObject fireEnemy = Instantiate(_enemyFactorys[(int)BasicEnemy.EnemyType.Fire], transform);
            
            _enemyPool[(int)BasicEnemy.EnemyType.Straight].Add(straightEnemy);
            _enemyPool[(int)BasicEnemy.EnemyType.Straight].Add(trackingEnemy);
            _enemyPool[(int)BasicEnemy.EnemyType.Straight].Add(fireEnemy);
            
            straightEnemy.SetActive(false);
            trackingEnemy.SetActive(false);
            fireEnemy.SetActive(false);
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
    
    private void SetItemPool()
    {
        _itemPool = new List<GameObject>();
        
        for (int i = 0; i < _itemPoolSize; i++)
        {
            GameObject item = Instantiate(_itemFactory, transform);
            
            _itemPool.Add(item);
            
            item.SetActive(false);
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
            bullet = Instantiate(_bulletFactory, GameManager.Instance.player.transform);
        }

        return bullet;
    }
    
    public GameObject GetEnemy(int index)
    {
        GameObject enemy = null;
        
        if (_enemyPool[index].Count > 0)
        {
            enemy = _enemyPool[index][0];
            _enemyPool[index].Remove(enemy);
        }
        else
        {
            enemy = Instantiate(_enemyFactorys[index], transform);
        }

        enemy.SetActive(true);
        
        return enemy;
    }

    public void SpawnExplosion(Vector3 position) => StartCoroutine(Explosion(position));
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
        
        if (_enemyBulletPool.Count > 0)
        {
            bullet = _enemyBulletPool[0];
            _enemyBulletPool.Remove(bullet);
        }
        else
        {
            bullet = Instantiate(_enemyBulletFactory, transform);
        }

        bullet.SetActive(true);

        return bullet;
    }
    
    public void SpawnItem(Vector3 position)
    {
        GameObject item = null;
        
        if (_itemPool.Count > 0)
        {
            item = _itemPool[0];
            _itemPool.Remove(item);
        }
        else
        {
            item = Instantiate(_enemyBulletFactory, transform);
        }

        item.transform.position = position;
        item.SetActive(true);
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        _bulletPool.Add(bullet);
    }

    public void ReturnEnemy(int index, GameObject enemy)
    {
        enemy.SetActive(false);
        _enemyPool[index].Add(enemy);
    }
    
    public void ReturnEnemyBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        _enemyBulletPool.Add(bullet);
    }

    public void ReturnItem(GameObject item)
    {
        item.SetActive(false);
        _itemPool.Add(item);
    }
}
