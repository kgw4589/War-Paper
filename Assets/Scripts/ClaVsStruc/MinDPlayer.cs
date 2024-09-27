using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MinDPlayer : MonoBehaviour
{
    public enum PlayerGameData
    {
        Fire = 100,
        Ice = 20,
        Physics = 3,
    }
    
    public enum EnemyGameData
    {
        Fire = 1,
        Ice = 2,
        Physics = 5,
    }
    
    void Start()
    {
        GameDataStruct.DamageNegation playerDmgNeg = 
            new GameDataStruct.DamageNegation((int)PlayerGameData.Fire, (int)PlayerGameData.Ice, (int)PlayerGameData.Physics);
        Debug.Log($"Player Damage Negateion Fire ={playerDmgNeg.Fire} / Ice ={playerDmgNeg.Ice} / Physics ={playerDmgNeg.Physics}");  
        
        GameDataStruct.EnemyDamageNegation enemyDmgNeg = 
            new GameDataStruct.EnemyDamageNegation((int)EnemyGameData.Fire, (int)EnemyGameData.Ice, (int)EnemyGameData.Physics);
        Debug.Log($"Enemy Damage Negation Fire ={enemyDmgNeg.Fire} / Ice ={enemyDmgNeg.Ice} / Physics ={enemyDmgNeg.Physics}");   
    }

    void Update()
    {
        
    }
}
