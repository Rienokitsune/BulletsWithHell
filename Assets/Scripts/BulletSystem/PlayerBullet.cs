using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{

    public int damage;

    public override void Update()
    {

        Timer += Time.deltaTime;
        rb.velocity = -transform.up * speedOverTime.Evaluate(time: 0);

    }

    public void SetDamage(int dmg)
    {
        damage = dmg;
    }
}
