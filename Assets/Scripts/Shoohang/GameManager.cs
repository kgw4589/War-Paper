using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;
    
    protected override void Init()
    {
        player = GameObject.FindWithTag("Player");
    }
}
