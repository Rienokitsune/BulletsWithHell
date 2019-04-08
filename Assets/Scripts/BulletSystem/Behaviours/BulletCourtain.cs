using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletBehaviour", menuName = "BulletBehaviours/CourtainEmitter(TODO)", order = 4)]
public class BulletCourtain : BulletBehaviour
{
    public float CourtainWidth; 
    public int numOfBullets;

    public override void Fire(Transform source)
    {
        //code that calculates vector representing a line based on two vector 2 positions. this vector is then divided and used as a step
        //to calcuate positions and rotations of bullets.

        // nothing works yet, it's planned feature duh

        /*for (int i = 0; i < numOfBullets ; i++)
        {
            currentPos = posEnd - posIncrement*(i+1) ; 
            GameObject laser = getPooledBullet(config.Pool_ID);
            laser.SetActive(true);
            laser.transform.position = currentPos;
            laser.transform.rotation = source.rotation;
            
            laser.GetComponent<Bullet>().speedOverTime = config.SpeedCurve;
        }
        */

    }
}
