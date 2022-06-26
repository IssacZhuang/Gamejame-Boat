using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuffDefOf
{
    // Original buff define
    public static BuffDef attack = new BuffDef("Buff_Attacked");
    public static BuffDef defend = new BuffDef("Buff_Defend");
    // Init multiple attack type
    public static BuffDef fireBallAttack = new BuffDef("Buff_FireBallAttack");
    public static BuffDef splitFireBallAttack = new BuffDef("Buff_SplitFireBallAttack");
    public static BuffDef meteoriteAttack = new BuffDef("Buff_MeteoriteAttack");
    public static BuffDef repelDebuff = new BuffDef("Buff_Repel");

    static BuffDefOf()
    {
        // Sample Attack code (we will not use it)
        attack.initialSeverity = 10;
        attack.workerClass = typeof(Buff_Attacked);

        // For Fireball Attack
        fireBallAttack.initialSeverity = 10;
        fireBallAttack.workerClass = typeof(Buff_Attacked);

        // For Meteorite Attack
        meteoriteAttack.initialSeverity = 20;
        meteoriteAttack.workerClass = typeof(Buff_Attacked);


        // For Split Fire Ball Attack
        fireBallAttack.initialSeverity = 10;
        fireBallAttack.workerClass = typeof(Buff_Attacked);

        // for repel debuff
        repelDebuff.workerClass = typeof(Buff_Repel);

        // Defend All Attack
        //defend.initialSeverity = 5;
        defend.immuniteBuffs.Add(attack);
        defend.immuniteBuffs.Add(fireBallAttack);
        defend.immuniteBuffs.Add(meteoriteAttack);
        defend.immuniteBuffs.Add(fireBallAttack);
    }
}
