using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Test_VerbAttackSplitFireBall : ThingComponent
{
    public GameObject attackObject;
    public override void CompPostStart()
    {
        base.CompPostStart();
        Verb_ShootSplitFireBall shoot = new Verb_ShootSplitFireBall();
        shoot.TrySetTarget(new TargetInfo { location = new Vector3(2, 0, 2) });
        shoot.objct = attackObject;
        Character character = parent as Character;
    
        character.VerbTracker.AddVerb(shoot);
        character.VerbTracker.NextVerb();
    }
}
