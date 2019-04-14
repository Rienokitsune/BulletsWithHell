
using UnityEngine;


public class BulletGeneric : Bullet
{
    public override void FixedUpdate()
    {
        
            Timer += Time.deltaTime;
            rb.velocity = -transform.up * speedOverTime.Evaluate(time: 0);
        
    }

   
}
