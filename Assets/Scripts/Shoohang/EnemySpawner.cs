using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform[] _spawnPoints;
    
    private float _spawnMinTime = 0.5f;
    private float _spawnMaxTime = 1.5f;

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
            GameObject enemy = ObjectPoolManager.Instance.GetEnemy();
            
            int index = Random.Range(0, _spawnPoints.Length);
            enemy.transform.position = _spawnPoints[index].position;

            _currentTime = Random.Range(_spawnMinTime, _spawnMaxTime);
            _currentTime = 0;
        }
    }
}
