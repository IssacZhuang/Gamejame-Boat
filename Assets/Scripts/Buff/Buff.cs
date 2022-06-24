using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    public float severity;
    public BuffDef def;
    public Character parent;

    public virtual bool MarkAsRemove
    {
        get
        {
            return false;
        }
    }

    public virtual void BuffPostAdd()
    {

    }
    public virtual void BuffTick()
    {

    }

    public virtual void OnRemoved()
    {
        def = null;
        parent = null;
    }

    public virtual void NotifiedNextStage()
    {

    }
}
