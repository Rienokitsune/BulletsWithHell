
using UnityEngine;


public class BulletGeneric : Bullet
{
    public override void Update()
    {
        
            Timer += Time.deltaTime;
            rb.velocity = -transform.up * speedOverTime.Evaluate(time: 0);
        
    }

   
}
