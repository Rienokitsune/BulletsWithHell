using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletBehaviour", menuName = "BulletBehaviours/GenericRotatingEmitter", order = 2)]
public class BulletRotatingEmitter : BulletBehaviour
{

    [SerializeField] [Range(0, 360)] int coneAngle;

    [Range(1, 20)]
    [SerializeField] int numOfBullets;
    [SerializeField] float rotationSpeed;
    float currentOffset;
    float pRotationAngle;

    private void OnEnable()
    {
        currentOffset = 0;
    }

    public override void Fire(Transform source)
    {
        pRotationAngle = coneAngle / numOfBullets;

        currentOffset += rotationSpeed * Time.deltaTime;

        for (int i = 0; i < numOfBullets; i++)
        {


            GameObject laser = getPooledBullet(config.Pool_ID);
            laser.SetActive(true);

            laser.transform.position = source.position;
            laser.transform.rotation = Quaternion.Euler(0, 0, ((i - numOfBullets / 2) * pRotationAngle) + currentOffset);
            laser.GetComponent<Bullet>().speedOverTime = config.SpeedCurve;

        }
    }
}
