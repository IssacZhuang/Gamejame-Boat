using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDefend : Buff
{
    public GameObject shield;

    public override void BuffPostAdd()
    {
        shield.SetActive(true);
    }

    public override void OnRemoved()
    {
        shield.SetActive(false);
        base.OnRemoved();
    }

}
