using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Attacked : Buff
{
    public override bool MarkAsRemove => true;
    public override void BuffPostAdd()
    {
        base.BuffPostAdd();
        this.parent.Health -= severity;
    }
}
