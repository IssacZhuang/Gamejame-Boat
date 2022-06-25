using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Verb_ShootFireBall : Verb
{
    public GameObject fireBall;

    public override bool TryCastVerb()
    {
        GameObject projectile = GameObject.Instantiate(fireBall);
        Projectile_Huge thing = projectile.GetComponent<Projectile_Huge>();
        Vector3 from = this.parent.transform.position;
        thing.Direction = new Vector2(Target.location.x - from.x, Target.location.z - from.z);
        return base.TryCastVerb();
    }
}
