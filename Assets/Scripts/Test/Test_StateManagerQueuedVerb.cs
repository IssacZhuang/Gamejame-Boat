using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Scaffold;

public class Test_StateManagerQueuedVerb:GameComponent
{

    public GameObject fireBall;
    public void Start()
    {
        StageManager stageManager = GetComponent<StageManager>();
        for (int i = 0; i < 2; i++)
        {
            stageManager.AddNewCharacter();
        }

        Verb playerOneMove = VerbDefOf.movementBasic.CreateVerb();
        playerOneMove.TrySetTarget(new TargetInfo { location = new Vector3(5, 0, 5) });

        Verb_ShootFireBall playerOneShoot = (Verb_ShootFireBall)VerbDefOf.attackFireball.CreateVerb();
        playerOneShoot.objct = fireBall;
        playerOneShoot.TrySetTarget(new TargetInfo { location = new Vector3(-10, 0, 10) });

        stageManager.Characters.ElementAt(0).VerbTracker.AddVerb(playerOneMove);
        stageManager.Characters.ElementAt(0).VerbTracker.AddVerb(playerOneShoot);

        Verb playerTwoMove = VerbDefOf.movementBasic.CreateVerb();
        playerTwoMove.TrySetTarget(new TargetInfo { location = new Vector3(-1, 0, 1) });

        Verb_ShootSplitFireBall playerTwoShoot = (Verb_ShootSplitFireBall)VerbDefOf.attackSplitFireball.CreateVerb();
        playerTwoShoot.objct = fireBall;
        playerTwoShoot.TrySetTarget(new TargetInfo { location = new Vector3(5, 0, 5) });

        stageManager.Characters.ElementAt(1).VerbTracker.AddVerb(playerTwoMove);
        stageManager.Characters.ElementAt(1).VerbTracker.AddVerb(playerTwoShoot);

        stageManager.StartQueuedVerbs();
    }
}
