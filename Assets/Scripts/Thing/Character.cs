using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Character : Thing
{
    public bool IsKilled => isKilled;
    private bool isKilled = false;

    public virtual Vector3 DrawPos => this.transform.position;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if (health <= 0) this.Kill();
        }
    }
    private float health = 100f;
    public BuffTracker BuffTracker { get; private set; }
    public VerbTracker VerbTracker { get; private set; }

    public Character()
    {
        BuffTracker = new BuffTracker(this);
        VerbTracker = new VerbTracker(this);
    }

    public override void ThingPostStart()
    {
        base.ThingPostStart();
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
