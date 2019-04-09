using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "PlayerWeaponConfig", menuName = "Player/WeaponConfig", order = 3)]
public class PlayerBulletBehaviour : ScriptableObject
{ 
    [SerializeField] public PlayerData data;
    [SerializeField] BulletConfig config;
    [SerializeField] [Range(0, 360)] int coneAngle;
    [Range(1, 20)]
    [SerializeField] int numOfBullets;
    [Range(-180, 180)]
    [SerializeField] float offsetZ;
    float pRotationAngle;

    [SerializeField] int[] damageAtLevel;
    [SerializeField][Range(0,1)] public float[] shotDelayAtLevel;


    public void Fire(Transform source)
    {

        pRotationAngle = coneAngle / numOfBullets;
        int Damage = damageAtLevel[data.GetLevel(UpgradeTypes.UpgradeType.Damage)];

        for (int i = 0; i < numOfBullets; i++)
        {


            GameObject laser = getPooledBullet(config.Pool_ID);
            laser.SetActive(true);

            laser.transform.position = source.position;
            laser.transform.rotation = Quaternion.Euler(0, 0, ((i - numOfBullets / 2) * pRotationAngle) + offsetZ);
            laser.GetComponent<PlayerBullet>().speedOverTime = config.SpeedCurve;
            laser.GetComponent<PlayerBullet>().SetDamage(Damage);

        }
    }

    public GameObject getPooledBullet(int ID)
    {
        return BulletPooler.pooler.getPooledObject(config.Pool_ID.ToString()); ;
    }

    public Transform GetTransform(GameObject obj)
    {
        return obj.transform;
    }
}
