using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameDataStruct
{
    public struct DamageNegation
    {
        public int Fire;
        public int Ice;
        public int Physics;
        
        public DamageNegation(int fire, int ice, int physics)
        {
            Fire = fire;
            Ice = ice;
            Physics = physics;
        }
    }

    public struct EnemyDamageNegation
    {
        public int Fire;
        public int Ice;
        public int Physics;
        
        public EnemyDamageNegation(int fire, int ice, int physics)
        {
            Fire = fire;
            Ice = ice;
            Physics = physics;
        }
    }

}
