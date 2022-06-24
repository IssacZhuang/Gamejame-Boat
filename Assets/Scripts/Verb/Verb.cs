using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verb
{
    private TargetInfo target;

    private bool isEnded = false;
    public bool IsEnded => isEnded;
    public Character parent;

    public bool TrySetTarget(TargetInfo info)
    {
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
        return true;
    }

    public virtual void VerbTick()
    {
        if (ShouldEndVerb)
        {
            isEnded= true;
            OnVerbEnd();
            return;
        }
    }

    public virtual void OnVerbEnd()
    {
        this.parent = null;
    }
}
