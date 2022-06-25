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
        projectileMain.transform.parent = this.parent.transform;
        Projectile_SplitFireBall fireBallMain = projectileMain.GetComponent<Projectile_SplitFireBall>();

        GameObject projectileUpper = GameObject.Instantiate(objct);
        projectileUpper.transform.parent = this.parent.transform;
        Projectile_SplitFireBall fireBallUpper = projectileUpper.GetComponent<Projectile_SplitFireBall>();

        GameObject projectileLower = GameObject.Instantiate(objct);
        projectileLower.transform.parent = this.parent.transform;
        Projectile_SplitFireBall fireBallLower = projectileLower.GetComponent<Projectile_SplitFireBall>();


        // some thing define need to fill
        Vector3 from = this.parent.transform.position;
        fireBallMain.direction = new Vector2(Target.location.x - from.x, Target.location.z - from.z);
        fireBallMain.deviateDegree = 0;
        // Call end script verb when verb end
        fireBallMain.ActionVerbEnd = () =>
        {
            this.OnVerbEnd();
            GameObject.Find("GameManager").GetComponent<Game>().DeregisterThing(fireBallMain);
        };

        // invoke
        GameObject.Find("GameManager").GetComponent<Game>().RegisterThing(fireBallMain);

        fireBallUpper.direction = new Vector2(Target.location.x - from.x, Target.location.z - from.z);
        fireBallUpper.deviateDegree = 30;
        // Call end script verb when verb end
        fireBallUpper.ActionVerbEnd = () =>
        {
            this.OnVerbEnd();
            GameObject.Find("GameManager").GetComponent<Game>().DeregisterThing(fireBallUpper);
        };

        // invoke
        GameObject.Find("GameManager").GetComponent<Game>().RegisterThing(fireBallUpper);

        fireBallLower.direction = new Vector2(Target.location.x - from.x, Target.location.z - from.z);
        fireBallLower.deviateDegree = -30;
        // Call end script verb when verb end
        fireBallLower.ActionVerbEnd = () =>
        {
            this.OnVerbEnd();
            GameObject.Find("GameManager").GetComponent<Game>().DeregisterThing(fireBallLower);
        };

        // invoke
        GameObject.Find("GameManager").GetComponent<Game>().RegisterThing(fireBallLower);
        return base.TryCastVerb();
    }
}
