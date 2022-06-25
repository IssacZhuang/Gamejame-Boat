using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Test_VerbAttackFireBall : ThingComponent
{
    public GameObject attackObject;
    public override void CompPostStart()
    {
        base.CompPostStart();
        Verb_ShootFireBall shoot = new Verb_ShootFireBall();
        shoot.TrySetTarget(new TargetInfo { location = new Vector3(-1, 0, -1) });
        shoot.objct = attackObject;
        Character character = parent as Character;
    
        character.VerbTracker.AddVerb(shoot);
        character.VerbTracker.NextVerb();
    }
}
