using Sirenix.OdinInspector;
using UnityEngine;

public abstract class BulletBehaviour : ScriptableObject
{
    [PropertyRange(0,2)]
    public float[] shotDelaySequence;
    public BulletConfig config;
    

    public abstract void Fire(Transform source);

    public GameObject getPooledBullet(int ID)
    {       
        return BulletPooler.pooler.getPooledObject(config.Pool_ID.ToString());;
    }

    public Transform GetTransform(GameObject obj)
    {
        return obj.transform;
    }
}
