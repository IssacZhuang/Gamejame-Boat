using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Scaffold;

public class Test_StateManagerQueuedVerb:GameComponent
{
    public void Start()
    {
        StageManager stageManager = GetComponent<StageManager>();
        for (int i = 0; i < 2; i++)
        {
            stageManager.AddNewCharacter();
        }

        Verb playerOneMove = VerbDefOf.movementBasic.CreateVerb();
        playerOneMove.TrySetTarget(new TargetInfo { location = new Vector3(2, 0, 2) });

        Verb playerOneShoot = VerbDefOf.movementBasic.CreateVerb();
        playerOneMove.TrySetTarget(new TargetInfo { location = new Vector3(-1, 0, 1) });

        stageManager.Characters.ElementAt(0).VerbTracker.AddVerb(playerOneMove);
        stageManager.Characters.ElementAt(0).VerbTracker.AddVerb(playerOneShoot);

        Verb playerTwoMove = VerbDefOf.movementBasic.CreateVerb();
        playerOneMove.TrySetTarget(new TargetInfo { location = new Vector3(-1, 0, 1) });

        Verb playerTwoShoot = VerbDefOf.movementBasic.CreateVerb();
        playerOneMove.TrySetTarget(new TargetInfo { location = new Vector3(2, 0, 2) });

        stageManager.Characters.ElementAt(1).VerbTracker.AddVerb(playerTwoMove);
        stageManager.Characters.ElementAt(1).VerbTracker.AddVerb(playerTwoShoot);

        stageManager.StartQueuedVerbs();
    }
}
