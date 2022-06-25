using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Huge : Projectile
{
    public override void HitCharacter(Character character)
    {
        //base.HitCharacter(character);
        character.BuffTracker.TryAddBuff(BuffDefOf.hugDamage);
    }
}
