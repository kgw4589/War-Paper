using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // 영역 안에 다른 물체가 감지될 경우
    private void OnTriggerEnter(Collider other)
    {
        // 1. 만약 부딪힌 물체가 Bullet이거나 Enemy라면
        if (other.gameObject.name.Contains("Bullet") ||
            other.gameObject.name.Contains("Enemy"))
        {
            // 2. 부딪힌 물체를 비활성화
            other.gameObject.SetActive(false);
            
            // 3. 부딪힌 물체가 총알일 경우 총알 리스트에 삽입
            if (other.gameObject.name.Contains("Bullet"))
            {
                // PlayerFire 클래스 얻어오기
                GameObject playerObject = GameObject.Find("Player");

                if (playerObject is not null)
                {
                    PlayerFire player = playerObject.GetComponent<PlayerFire>();    
                    // 리스트에 총알 삽입
                    player.bulletObjectPool.Add(other.gameObject);
                }
            }
            else if (other.gameObject.name.Contains("Enemy"))
            {
                GameObject enemyManagerObject = GameObject.Find("EnemyManager");
                EnemyManager enemyManager = enemyManagerObject.GetComponent<EnemyManager>();
                enemyManager.enemyObjectPool.Add(other.gameObject);
            }
        }
    }
}
