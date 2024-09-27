using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 최소 시간
    private float _minTime = 0.5f;
    // 최대 시간
    private float _maxTime = 1.5f;
    
    // 일정 시간
    public float createTime = 1f;
    // 적 공장
    public GameObject enemyFactory;
    
    // 현재 시간
    private float _currentTime;
    
    // 오브젝트 풀 크기
    public int poolSize = 10;
    // 오브젝트 풀 배역
    public List<GameObject> enemyObjectPool;
    // SpawnPoint들
    public Transform[] spawnPoints;
    
    // 1. 태어날 때
    private void Start()
    {
        // 태어날 때 적의 생성시간을 설정하고
        createTime = Random.Range(_minTime, _maxTime);
        
        // 2. 오브젝트 풀을 에너미들을 담을 수 있는 크기로 만들어준다.
        enemyObjectPool = new List<GameObject>();
        
        // 3. 오브젝트 풀에 넣을 에너미 개수만큼 반복해
        for (int i = 0; i < poolSize; i++)
        {
            // 4. 에너미 공장에서 에너미를 생산한다.
            GameObject enemy = Instantiate(enemyFactory);
            // 5. 에너미를 오브젝트 풀에 넣고 싶다.
            enemyObjectPool.Add(enemy);
            // 비활성화 시키자
            enemy.SetActive(false);
        }
    }

    private void Update()
    {
        // 1. 시간이 흐르다가
        _currentTime += Time.deltaTime;
        
        // 1. 생성 시간이 됐으니까
        if (_currentTime > createTime)
        {
            // 2. 오브젝트 풀에 에너미가 있다면
            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];
                // 3. 에너미 활성화
                enemy.SetActive(true);
                
                // 4. 오브젝트 풀에서 에너미 삭제
                enemyObjectPool.Remove(enemy);
                
                // 랜덤으로 인덱스 선택
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
            }
            
            _currentTime = Random.Range(_minTime, _maxTime);
            _currentTime = 0;
        }
    }
}
