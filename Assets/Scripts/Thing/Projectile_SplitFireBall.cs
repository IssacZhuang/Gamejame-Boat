using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using Scaffold;

public class Projectile_SplitFireBall : Projectile
{

    public int deviateDegree=0;

    public override void ProjectileMove()
    {
        var targetDirection = Vector3.Normalize(direction);
        this.transform.Translate(Quaternion.Euler(0, deviateDegree, 0) * new Vector3(targetDirection.x * speed * Time.deltaTime, 0, targetDirection.y * speed * Time.deltaTime));
    }
}
