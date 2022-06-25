using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VerbDef : Def
{

    public VerbDef() { }

    public VerbDef(string defName)
    {
        this.defName = defName;
    }

    //for attack
    public float initialSeverity;
    //public Type workerClass = typeof(Verb);




}
