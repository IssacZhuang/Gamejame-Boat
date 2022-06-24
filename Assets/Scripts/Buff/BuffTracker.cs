using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BuffTracker
{
    public List<Buff> Buffs => buffs;
    private List<Buff> buffs = new List<Buff>();

    private Character parent;
    private Buff tmpBuff;

    public BuffTracker(Character parent)
    {
        this.parent = parent;
    }

    public void BuffTrackerTick()
    {
        int tmpLength = buffs.Count;
        int i = 0;
        while (i < tmpLength)
        {
            tmpBuff = buffs.ElementAt(i);
            if (tmpBuff.MarkAsRemove)
            {
                buffs.Remove(tmpBuff);
                tmpLength--;
                continue;
            }
            tmpBuff.BuffTick();
            i++;
        }
        tmpLength = 0;
        tmpBuff = null;
    }   

    public bool TryAddBuff(BuffDef def)
    {
        if (buffs.AsParallel().Any(x => x.def.immuniteBuffs.Contains(def)))
        {
            return false;
        }

        Buff worker = (Buff)Activator.CreateInstance(def.workerClass);
        worker.severity = def.initialSeverity;
        worker.def = def;
        worker.parent = this.parent;
        buffs.Add(worker);
        worker.BuffPostAdd();
        return true;
    }

    public void RemoveBuff(Buff buff)
    {
        buffs.Remove(buff);
    }

    public void RemoveBuff(BuffDef def)
    {
        foreach(var buff in buffs.Where(x => x.def == def))
        {
            buffs.Remove(buff);
        }
    }

    public void NotifiedNextStage()
    {
        buffs.ForEach(x => { x.NotifiedNextStage(); });
    }
}
