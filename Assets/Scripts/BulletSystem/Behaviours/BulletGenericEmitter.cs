using UnityEngine;

[CreateAssetMenu(fileName = "BulletBehaviour", menuName = "BulletBehaviours/GenericEmitter", order = 1)]
public class BulletGenericEmitter : BulletBehaviour
{

    [SerializeField][Range(0,360)] int coneAngle;

    [Range(1, 20)]
    [SerializeField] int numOfBullets;
    [Range(-180,180)]
    [SerializeField] float offsetZ;
    float pRotationAngle;
    
    public override void Fire(Transform source)
    {
        
        pRotationAngle = coneAngle / numOfBullets; 


        for (int i = 0; i< numOfBullets; i++)
        {


            GameObject laser = getPooledBullet(config.Pool_ID);
            laser.SetActive(true);

            laser.transform.position = source.position;
            laser.transform.rotation = Quaternion.Euler(0, 0, ((i- numOfBullets / 2) * pRotationAngle) + offsetZ );
            laser.GetComponent<Bullet>().speedOverTime = config.SpeedCurve;
            
        }
    }
}
