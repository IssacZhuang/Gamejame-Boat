using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VerbDefOf
{
    public static VerbDef attackFireball = new VerbDef("Verb_Attack_Fireball");
    public static VerbDef attackMeteorolite = new VerbDef("Verb_Attack_Meteorolite");
    public static VerbDef attackSplitFireball = new VerbDef("Verb_Attack_SplitFireball");
    public static VerbDef attackTrackFireball = new VerbDef("Verb_Attack_TrackFireball");
    public static VerbDef defendBasic = new VerbDef("Verb_Defend_BasicDefend");
    public static VerbDef movementBasic = new VerbDef("Verb_Movement_BasicMovement");
    public static VerbDef movementSwap = new VerbDef("Verb_Movement_Swap");

    static VerbDefOf()
    {

        attackFireball.workerClass = typeof(Verb_ShootFireBall);
        attackMeteorolite.workerClass = typeof(Verb_ShootMeteorite);
        attackSplitFireball.workerClass = typeof(Verb_ShootSplitFireBall);

        defendBasic.workerClass = typeof(Verb_Defend);
        movementBasic.workerClass = typeof(Verb_Move);
    }
}
