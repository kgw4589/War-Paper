using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    
    // 필요 속서 : 이동 속도
    public float speed = 5f;
    
    // 방향을 전역 변후로 만들어 Start()와 Update()에서 사용
    private Vector3 dir;
    
    // 폭발 공장 주소(외부에서 값을 넣어준다)
    public GameObject explosionFactory; 
    
    private void Start()
    {
        // 0부터 9까지 10개의 값 중에 하나를 랜덤으로 가져온다
        int randValue = Random.Range(0, 10);
        
        // 만약 3보다 작으면 플레이어 방향
        if (randValue < 3)
        {
            // 플레이어를 찾아 target으로 하고 싶다
            GameObject target = GameObject.Find("Player");
            if (target is not null)
            {
                // 방향을 구하고 싶다. target-me
                dir = target.transform.position - transform.position;
                // 방향의 크기를 1로 하고 싶다
                dir.Normalize();
            }
        }
        else // 그렇지 않으면 아래 방향으로 정하고 싶다
        {
            dir = Vector3.down;
        }
    }

    private void Update()
    {
        // 2. 이동하고 싶다. 공식 P = P0 + vt
        transform.position += dir * (speed * Time.deltaTime);
    }
    
    // 충돌 시작
    // 1. 적이 다른 물체와 충돌했으니까
    private void OnCollisionEnter(Collision other)
    {
        ScoreManager.Instance.Score++;
        
        // 2. 폭발 효과 공장에서 폭발 효과를 하나 만들어야 한다.
        GameObject explosion = Instantiate(explosionFactory);
        // 3. 폭발 효과를 발생(위치)시키고 싶다.
        explosion.transform.position = transform.position;
        // 만약 부딪힌 물체가 Bullet인 경우에는 비활성화 시켜서 탄창에 다시 넣어준다.
        // 1. 만약 부딪힌 물체가 Bullet이라면
        if (other.gameObject.name.Contains("Bullet"))
        {
            // 2. 부딪힌 물체를 비활성화
            other.gameObject.SetActive(false);
        }
        else
        {
            // 3. 그렇지 않으면 제거
            Destroy(other.gameObject);
        }
        // Destroy로 없애는 대신, 비활성화해 풀에 자원을 반납한다.
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
