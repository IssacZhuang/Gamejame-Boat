using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Verb_ShootSplitFireBall : Verb
{
    public GameObject objct;

    public override bool TryCastVerb()
    {
        // init object
        GameObject projectileMain = GameObject.Instantiate(objct);
        Projectile fireBallMain = projectileMain.GetComponent<Projectile>();

        GameObject projectileUpper = GameObject.Instantiate(objct);
        Projectile fireBallUpper = projectileUpper.GetComponent<Projectile>();

        GameObject projectileLower = GameObject.Instantiate(objct);
        Projectile fireBallLower = projectileLower.GetComponent<Projectile>();


        // some thing define need to fill
        Vector3 from = this.parent.transform.position;
        fireBallMain.direction = new Vector3(Target.location.x - from.x, 0, Target.location.z - from.z);
        fireBallMain.transform.position = from + fireBallMain.direction.normalized * 3f;
        // Call end script verb when verb end
        fireBallMain.ActionVerbEnd = () =>
        {
            this.OnVerbEnd();
        };


        fireBallUpper.direction = new Vector3(Target.location.x - from.x, 0, Target.location.z - from.z);
        fireBallUpper.direction = Quaternion.Euler(0, 30f, 0) * fireBallUpper.direction;
        fireBallUpper.transform.position = from + fireBallUpper.direction.normalized * 3f;
        // Call end script verb when verb end
        fireBallUpper.ActionVerbEnd = () =>
        {
            this.OnVerbEnd();
        };



        fireBallLower.direction = new Vector3(Target.location.x - from.x, 0, Target.location.z - from.z);
        fireBallLower.direction = Quaternion.Euler(0, -30f, 0) * fireBallLower.direction;
        fireBallLower.transform.position = from + fireBallLower.direction.normalized * 3f;
        // Call end script verb when verb end
        fireBallLower.ActionVerbEnd = () =>
        {
            this.OnVerbEnd();
        };

        return base.TryCastVerb();
    }
}
