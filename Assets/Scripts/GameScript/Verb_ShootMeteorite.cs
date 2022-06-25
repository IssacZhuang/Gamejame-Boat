using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using Scaffold;

public class Verb_ShootMeteorite : Verb
{
    public GameObject objct;
    public float distance = 5;

    public override bool TryCastVerb()
    {
        GameObject projectile = GameObject.Instantiate(objct);

        // set position
        var positionCreated = this.parent.transform.position + new Vector3(0, 10, 0);
        projectile.transform.position = positionCreated;

        Projectile thing = projectile.GetComponent<Projectile>();
        // some thing define need to fill
        thing.direction = Target.location - positionCreated;
        // Call end script verb when verb end
        thing.ActionVerbEnd = () =>
        {
            AddDamageAndForce();
            this.OnVerbEnd();
        };

        return base.TryCastVerb();
    }

    private void AddDamageAndForce()
    {
        var targets = Find.CurrentGame.Things.Where(x => x is Character && Vector3.Distance(x.transform.position, this.parent.transform.position) <= distance);
        Character tmpCharacter = null;
        foreach(var target in targets)
        {
            tmpCharacter = target as Character;
            tmpCharacter.BuffTracker.TryAddBuff(BuffDefOf.attack);
            Buff_Repel buff_Repel = (Buff_Repel)BuffDefOf.repelDebuff.CreateBuff();
            buff_Repel.direction = (target.transform.position - this.parent.transform.position);
            buff_Repel.direction.Set(buff_Repel.direction.x, 0, buff_Repel.direction.z);
            tmpCharacter.BuffTracker.TryAddBuff(buff_Repel);
        }
 
    }
}
