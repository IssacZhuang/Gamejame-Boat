using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbTracker 
{
    private Verb currentVerb;
    private Queue<Verb> pendingVerbs = new Queue<Verb>();
    private Character parent;

    public bool IsCurrentVerbOnGoing => currentVerb != null && !currentVerb.IsEnded;

    public VerbTracker(Character character)
    {
        this.parent = character;
    }

    public void VerbTrackerTick()
    {
        if (currentVerb != null && !currentVerb.IsEnded) currentVerb.VerbTick();

    }

    public void AddVerb(Verb verb)
    {
        verb.parent = this.parent;
        pendingVerbs.Enqueue(verb);
    }

    public Verb PeekVerb()
    {
        return pendingVerbs.Peek();
    }

    public void NextVerb()
    {
        if (currentVerb != null && !currentVerb.IsEnded)
        {
            currentVerb.OnVerbEnd();
            currentVerb = null;
        }
        if (pendingVerbs.Count > 0)
        {
            currentVerb = pendingVerbs.Dequeue();
        }
        currentVerb?.TryCastVerb();
    }
}
