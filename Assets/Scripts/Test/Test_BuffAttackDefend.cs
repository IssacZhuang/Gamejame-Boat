using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Test_BuffAttackDefend : ThingComponent
{
    public override void CompPostStart()
    {
        base.CompPostStart();
        Debug.Log("[Test] buff attacked and defend----------------");
        Character player = parent as Character;
        Debug.Log("Health before attakced: " + player.Health);
        player.BuffTracker.TryAddBuff(BuffDefOf.attack);
        Debug.Log("Health after attakced: " + player.Health);
        Debug.Log("Now player try defned.");
        player.BuffTracker.TryAddBuff(BuffDefOf.defend);
        player.BuffTracker.TryAddBuff(BuffDefOf.attack);
        Debug.Log("Health after defend the attack: " + player.Health);
    }
}

