﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenericVarSpeed : Bullet
{
    public override void Update()
    {

        Timer += Time.deltaTime;
        rb.velocity = -transform.up * speedOverTime.Evaluate(Timer);

    }
}
