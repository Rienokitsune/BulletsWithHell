using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig",menuName = "BulletConfig", order = 1) ]
public class BulletConfig : ScriptableObject
{
    [SerializeField]BulletPools poolList;
    public int Pool_ID;
    [PreviewField]
    [ShowInInspector]GameObject bulletPrefab;
    public string bulletType;
    public AnimationCurve SpeedCurve;
    

    private void OnEnable()
    {
        bulletPrefab = poolList.pools[Pool_ID].prefab;
        bulletType = bulletPrefab.GetComponent<Bullet>().GetType().ToString();
    }

}
