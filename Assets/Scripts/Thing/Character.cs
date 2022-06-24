using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Character : Thing
{
    public bool IsKilled => isKilled;
    private bool isKilled = false;

    public BuffTracker BuffTracker { get; private set; }
    public VerbTracker VerbTracker { get; private set; }

    public override void ThingPostStart()
    {
        base.ThingPostStart();
        BuffTracker = new BuffTracker();
        VerbTracker = new VerbTracker();
    }

    public override void ThingFixedUpdate()
    {
        if (isKilled) return;
        base.ThingFixedUpdate();
        BuffTracker.BuffTrackerTick();
        VerbTracker.VerbTrackerTick();
    }

    public override void ThingUpdate()
    {
        if (isKilled) return;
        base.ThingUpdate();
    }

    public override void ThingOnGUI()
    {
        if (isKilled) return;
        base.ThingOnGUI();
    }

    public virtual void Kill()
    {
        isKilled = true;
    }
}
