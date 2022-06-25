using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verb_Move : Verb
{
    private Vector3 from;
    private Vector3 direction;

    private const float timeCost = 1f;
    private readonly float progressStep = Time.fixedDeltaTime / timeCost;

    private float progress = 0;
    private Vector3 tmpDirection;

    public override bool ShouldEndVerb => progress >= 1;
    public override bool TryCastVerb()
    {
        from = this.parent.transform.position;
        direction = Target.location - from;
        return base.TryCastVerb();
    }

    public override void VerbTick()
    { 
        Debug.Log("progress: " + progress);
        progress += progressStep;
        tmpDirection = direction * progress;
        tmpDirection.Set(tmpDirection.x, 0, tmpDirection.x);
        parent.transform.position = from + tmpDirection;

        base.VerbTick();
    }

}
