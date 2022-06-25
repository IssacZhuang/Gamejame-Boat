using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BuffDef :Def
{
    public BuffDef() { }
    public BuffDef(string defName)
    {
        this.defName = defName;
    }

    public float initialSeverity;
    public Type workerClass = typeof(Buff); //default worker class
    public List<BuffDef> immuniteBuffs = new List<BuffDef> ();
}
