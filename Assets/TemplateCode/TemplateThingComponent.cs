using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class TemplateThingComponent : ThingComponent
{
    public override void CompPostStart()
    {
        base.CompPostStart();
        Debug.Log("From thing component");
        //Todo
    }

    public override void CompPreDetroy()
    {
        base.CompPreDetroy();
        //Todo
    }

    public override void CompFixedUpdate()
    {
        base.CompFixedUpdate();
        //Todo
    }

    public override void CompUpdate()
    {
        base.CompUpdate();
        //Todo
    }


    public override void CompOnGUI()
    {
        base.CompOnGUI();
        //Todo
    }
}
