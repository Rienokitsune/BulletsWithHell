using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{

    [SerializeField]public int damage;

    public override void Update()
    {

        Timer += Time.deltaTime;
        rb.velocity = -transform.up * speedOverTime.Evaluate(time: 0);

    }
}
