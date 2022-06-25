using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verb_Defend : Verb
{
    public override bool TryCastVerb()
    {
        parent.BuffTracker.TryAddBuff(BuffDefOf.defend);
        return base.TryCastVerb();
    }

    public override void OnVerbEnd()
    {
        parent.BuffTracker.RemoveBuff(BuffDefOf.defend);
        base.OnVerbEnd();
    }
}
