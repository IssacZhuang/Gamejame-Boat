using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using Scaffold;

public class Projectile_SplitFireBall : Thing
{
    // predefined parameter 
    public Vector2 direction;
    public int deviateDegree=0;
    public float speed = 5.0f;
    // for callback action verb
    public Action ActionVerbEnd;
    // for other two directions
    private long startTime;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Find.CurrentGame.GlobalTick;
    }

    public override void ThingFixedUpdate()
    {
        var targetDirection = Vector3.Normalize(direction);
        this.transform.Translate(Quaternion.Euler(0, deviateDegree, 0) * new Vector3(targetDirection.x * speed * Time.deltaTime, 0, targetDirection.y * speed * Time.deltaTime));

        //越界判断
        if (Find.CurrentGame.GlobalTick - startTime > 50 * 5) //at most last 5s
        {
            if (ActionVerbEnd != null) ActionVerbEnd();
            Destroy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();
        if (character != null)
        {
            HitCharacter(character);
            Destroy();
        }
        else
        {
            // if collited floor
            Destroy();
        }
    }


    public void HitCharacter(Character character)
    {
        if (ActionVerbEnd != null) ActionVerbEnd();
        character.BuffTracker.TryAddBuff(BuffDefOf.splitFireBallAttack);
    }
}
