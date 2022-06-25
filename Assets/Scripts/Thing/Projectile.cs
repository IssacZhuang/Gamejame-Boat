using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using Scaffold;

public class Projectile : Thing
{
    public Action ActionVerbEnd;

    public float speed = 5.0f;
    public Vector3 direction;
    private long startTime;



    public override void ThingPostStart()
    {
        base.ThingPostStart();
        startTime = Find.CurrentGame.GlobalTick;
        direction.Normalize();
    }

    // Update is called once per frame
    public override void ThingFixedUpdate()
    {
        ProjectileMove();
        //越界判断
        if (Find.CurrentGame.GlobalTick - startTime > 50 * 5) //at most last 5s
        {
            if (ActionVerbEnd != null) ActionVerbEnd();
            Destroy();
        }
    }

    public virtual void ProjectileMove()
    {
        transform.Translate(new Vector3(direction.x * speed * Time.fixedDeltaTime, direction.y * speed * Time.fixedDeltaTime, direction.z * speed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();
        if (character != null)
        {
            HitCharacter(character);
        }
        Destroy();
    }

    public virtual void HitCharacter(Character character)
    {
        if (ActionVerbEnd != null) ActionVerbEnd();
        character.BuffTracker.TryAddBuff(BuffDefOf.attack);
        // define a repel buff
        Buff_Repel repelBuff = (Buff_Repel)BuffDefOf.repelDebuff.CreateBuff();
        repelBuff.direction = direction;
        character.BuffTracker.TryAddBuff(repelBuff);
    }

    public void OnDestroy()
    {
        if (ActionVerbEnd != null) ActionVerbEnd();
    }
}
