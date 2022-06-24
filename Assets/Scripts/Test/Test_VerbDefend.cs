using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_VerbDefend : MonoBehaviour
{
    void Start()
    {
        Debug.Log("[Test] verb defend ----------------");
        Character player = new Character();
        Debug.Log("Health before attakced: " + player.Health);
        player.BuffTracker.TryAddBuff(BuffDefOf.attack);
        Debug.Log("Health after attakced: " + player.Health);
        Debug.Log("Now player start Verb_Defend.");
        player.VerbTracker.AddVerb(new Verb_Defend());
        player.VerbTracker.NextVerb();
        Debug.Log("Health after defend the attack: " + player.Health);
        player.VerbTracker.NextVerb();
        Debug.Log("Now move to next verb, Verb_Defend end.");
        Debug.Log("Health before attakced: " + player.Health);
        player.BuffTracker.TryAddBuff(BuffDefOf.attack);
        Debug.Log("Health after attakced: " + player.Health);
    }

}
