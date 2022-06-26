using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verb
{
    public TargetInfo Target => target;
    private TargetInfo target;

    private bool isEnded = true;
    public bool IsEnded => isEnded;
    public Character parent;

    public VerbDef def;

    public bool TrySetTarget(TargetInfo info)
    {
        //Debug.Log("info.location.x:"+ info.location.x);
        //Debug.Log("info.location.y:"+ info.location.y);
        //Debug.Log("info.location.z:"+ info.location.z);
        if (TargetValidator(info))
        {
            target = info;
            return true;
        }

        return false;
    }

    public virtual bool ShouldEndVerb => false;

    public virtual bool TargetValidator(TargetInfo info)
    {
        return true;
    }

    public virtual bool TryCastVerb()
    {
        isEnded = false;
        return true;
    }

    public virtual void VerbTick()
    {
        if (ShouldEndVerb && !isEnded)
        {
            isEnded = true;
            OnVerbEnd();
            return;
        }
    }

    public virtual void OnVerbEnd()
    {
        this.parent = null;
    }
}
