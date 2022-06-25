using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class VerbDef : Def
{
    public Texture2D UITexture;
    public bool shouldLocateTarget;
    public int priority;
    public Type workerClass = typeof(Verb);

    public VerbDef()
    {

    }

    public VerbDef(string defName)
    {
        this.defName = defName;
    }

    public Verb CreateVerb()
    {
        Verb verb = (Verb)Activator.CreateInstance(this.workerClass);
        verb.def = this;
        return verb;
    }
}
