using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform[] _spawnPoints;
    
    private float _spawnMinTime = 0.25f;
    private float _spawnMaxTime = 1f;

    private float _createTime = 0f;
    private float _currentTime = 0f;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
        
        _createTime = Random.Range(_spawnMinTime, _spawnMaxTime);
    }
    
    private void Update()
    {
        _currentTime += Time.deltaTime;
        
        if (_currentTime > _createTime)
        {
            SpawnEnemy();
            
            _createTime = Random.Range(_spawnMinTime, _spawnMaxTime);
            _currentTime = 0;
        }
    }

    private void SpawnEnemy()
    {
        BasicEnemy.EnemyType enemyType = BasicEnemy.EnemyType.Straight;
        
        int randomValue = Random.Range(0, 10);

        if (randomValue < 3)
        {
            enemyType = BasicEnemy.EnemyType.Straight;
        }
        else if (randomValue < 5)
        {
            enemyType = BasicEnemy.EnemyType.Tracking;
        }
        else
        {
            enemyType = BasicEnemy.EnemyType.Fire;
        }
        
        int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
        
        GameObject enemy = ObjectPoolManager.Instance.GetEnemy((int)enemyType);
        Debug.Log(enemy.gameObject.name);
        enemy.transform.position = _spawnPoints[spawnPointIndex].position;
    }
}
