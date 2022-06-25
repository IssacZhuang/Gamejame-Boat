using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Verb_ShootMeteorite : Verb
{
    public GameObject objct;

    public override bool TryCastVerb()
    {
        GameObject projectile = GameObject.Instantiate(objct);
        // set transform
        projectile.transform.parent = this.parent.transform;
        // set position
        var positionCreated = this.parent.transform.position + new Vector3(0, 5, 0);
        projectile.transform.position = positionCreated;

        Projectile thing = projectile.GetComponent<Projectile>();
        // some thing define need to fill
        thing.direction = Target.location - positionCreated;
        // Call end script verb when verb end
        thing.ActionVerbEnd = () =>
        {
            this.OnVerbEnd();
        };

        return base.TryCastVerb();
    }
}
