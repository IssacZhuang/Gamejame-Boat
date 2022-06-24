using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Test_BuffAttackDefend : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[Test] buff attacked and defend----------------");
        Character player = new Character();
        Debug.Log("Health before attakced: " + player.Health);
        player.BuffTracker.TryAddBuff(BuffDefOf.attack);
        Debug.Log("Health after attakced: " + player.Health);
        Debug.Log("Now player try defned.");
        player.BuffTracker.TryAddBuff(BuffDefOf.defend);
        player.BuffTracker.TryAddBuff(BuffDefOf.attack);
        Debug.Log("Health after defend the attack: " + player.Health);
    }
}
