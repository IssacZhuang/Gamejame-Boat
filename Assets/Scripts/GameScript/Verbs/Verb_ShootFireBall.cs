using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Verb_ShootFireBall : Verb
{
    public GameObject objct;

    public override bool TryCastVerb()
    {
        GameObject projectile = GameObject.Instantiate(objct);
        projectile.transform.parent = this.parent.transform;
        Projectile_FireBall thing = projectile.GetComponent<Projectile_FireBall>();
        // Something <Projectile_FireBall> defined need to fill
        // for direction
        Vector3 from = this.parent.transform.position;
        thing.direction = new Vector2(Target.location.x - from.x, Target.location.z - from.z);
        // Call end script verb when verb end
        thing.ActionVerbEnd = () =>
        {
            this.OnVerbEnd();
            GameObject.Find("GameManager").GetComponent<Game>().DeregisterThing(thing);
        };

        // invoke
        GameObject.Find("GameManager").GetComponent<Game>().RegisterThing(thing);

        return base.TryCastVerb();
    }
}
