using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;
using DigitalRuby.SoundManagerNamespace;

public class Verb_ShootFireBall : Verb
{
    public GameObject objct;
    public GameObject sm;

    public override bool TryCastVerb()
    {
        sm = GameObject.Find("SoundManager");
        // audio play
        sm.GetComponent<SoundManagerDemo>().PlaySound(4);

        GameObject projectile = GameObject.Instantiate(objct);
        //projectile.transform.parent = this.parent.transform;
        Projectile thing = projectile.GetComponent<Projectile>();
        // Something <Projectile_FireBall> defined need to fill
        // for direction
        Vector3 from = this.parent.transform.position;
        thing.direction = new Vector3(Target.location.x - from.x, 0, Target.location.z - from.z);
        thing.transform.position = from + thing.direction.normalized*3f;

        // Call end script verb when verb end
        thing.ActionVerbEnd = () =>
        {
            this.OnVerbEnd();
        };


        return base.TryCastVerb();
    }
}
