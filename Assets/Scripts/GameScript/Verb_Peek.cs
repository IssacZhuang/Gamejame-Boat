using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verb_Peek : Verb
{
    public Character targetCharacter;

    public void AssignTarget(Character c)
    {
        targetCharacter = c.GetComponent<Character>();
    }
    public override bool TryCastVerb()
    {
        return base.TryCastVerb();
    }
}

