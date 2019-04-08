using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletPool", menuName = "Bullet Pool", order = 3)]
public class BulletPools : ScriptableObject
{

    public List<Pool> pools;

    public List<Pool> getPools()
    {       
        return pools;
    }
}
