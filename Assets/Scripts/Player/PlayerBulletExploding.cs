using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletExploding : PlayerBullet
{
    [SerializeField] PlayerBulletBehaviour explosion;
    [SerializeField] float explosionDelay;
    [SerializeField] string ExplosionBullet_ID;


    public override void FixedUpdate()
    {
        Timer += Time.deltaTime;
        rb.velocity = -transform.up * speedOverTime.Evaluate(time: 0);
        if(Timer >= explosionDelay)
        {
            Hit();
        }
    }

    public override void Hit()
    {
        explosion.Fire(this.transform);
        base.Hit();
    }

   
}
