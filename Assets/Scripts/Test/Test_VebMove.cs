using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Test_VebMove : ThingComponent
{
    public override void CompPostStart()
    {
        base.CompPostStart();
        Verb_Move move = new Verb_Move();
        move.TrySetTarget(new TargetInfo { location = new Vector3(1, 0, 1) });
        Character character = parent as Character;
        character?.VerbTracker.AddVerb(move);
        character?.VerbTracker.NextVerb();

    }
}
