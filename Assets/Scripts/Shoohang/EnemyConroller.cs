using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConroller : BasicPlane
{
    private GameObject _target;
    
    private void Start()
    {
        _target = GameManager.Instance.player;
    }
    
    private void Update()
    {
        // RotXValue = (_target.transform.position.y > transform.position.y) ? -1 : 1;
        // RotZValue = (_target.transform.position.x > transform.position.x) ? -1 : 1;
        
        transform.LookAt(_target.transform);
    } 
}
