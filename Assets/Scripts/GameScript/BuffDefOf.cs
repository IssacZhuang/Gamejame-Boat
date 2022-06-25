using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuffDefOf
{
    public static BuffDef attack = new BuffDef("Buff_Attacked");
    public static BuffDef defend = new BuffDef("Buff_Defend");
    public static BuffDef hugDamage = new BuffDef("Buff_HugDamage");
    static BuffDefOf()
    {
        attack.initialSeverity = 25;
        attack.workerClass = typeof(Buff_Attacked);

        hugDamage.initialSeverity = 70;
        hugDamage.workerClass = typeof(Buff_Attacked);

        defend.immuniteBuffs.Add(attack);
    }
}
