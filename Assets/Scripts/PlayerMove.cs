using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 플레이어가 이동할 속력
    public float speed = 5f;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);
        
        // transform.Translate(dir * speed * Time.deltaTime);    
        // P = P0 + vt 공식으로 변경
        transform.position += dir * (speed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        Debug.Log($"Destroyed!!");
    }
}
