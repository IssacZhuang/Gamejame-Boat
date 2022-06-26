using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verb_Defend : Verb
{
    public GameObject objct;
    public override bool TryCastVerb()
    {
        GameObject shield = Object.Instantiate(objct, new Vector3(0,0,0), Quaternion.identity);
        shield.transform.SetParent(parent.transform);
        shield.transform.localPosition = new Vector3(0, 0, 0);
        var buff = (BuffDefend)BuffDefOf.defend.CreateBuff();
        buff.shield = shield;

        parent.BuffTracker.TryAddBuff(buff);
        
        return base.TryCastVerb();
    }

    public override bool ShouldEndVerb => true;

    public override void OnVerbEnd()
    {
        parent.BuffTracker.RemoveBuff(BuffDefOf.defend);
        base.OnVerbEnd();
    }
}
