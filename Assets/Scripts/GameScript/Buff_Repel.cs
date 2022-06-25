using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Repel : Buff
{
    public Vector3 direction;
    public float distance = 1.5f;
    public float speed = 3f;

    private float distanceMoved = 0f;

    public override void BuffPostAdd()
    {
        direction.Normalize();
    }

    public override void BuffTick()
    {
        base.BuffTick();
        if (distanceMoved >= distance || parent == null) OnRemoved();
        Vector3 displacement = direction * Time.fixedDeltaTime * speed;
        this.parent.transform.position += displacement;

        distanceMoved += displacement.sqrMagnitude;
        
    }
}
