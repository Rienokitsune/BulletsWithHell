
using UnityEngine;
[CreateAssetMenu(fileName = "BulletBehaviour", menuName = "BulletBehaviours/ExplodingEmitter", order = 3)]
public class BulletExplodingEmitter : BulletBehaviour
{

    [Range(1, 20)]
    [SerializeField] int numOfBullets;
    float pRotationAngle;

    public override void Fire(Transform source)
    {
        pRotationAngle = 360 / numOfBullets;

        for (int i = 0; i < numOfBullets; i++)
        {
            GameObject laser = getPooledBullet(config.Pool_ID);
            laser.SetActive(true);
            laser.transform.position = source.position;
            laser.transform.rotation = Quaternion.Euler(0, 0, ((i - numOfBullets / 2) * pRotationAngle));
            laser.GetComponent<Bullet>().speedOverTime = config.SpeedCurve;
        }
    }
}
