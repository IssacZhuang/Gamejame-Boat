using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class TemplateThing : Thing
{
    public override void ThingPostStart()
    {
        base.ThingPostStart();
        Debug.Log("From thing class");

        //Tempalte code for simple curve
        SimpleCurve curve = new SimpleCurve();
        curve.Add(0, 0);
        curve.Add(0.5f, 0.2f);
        curve.Add(1f, 1f);
        Debug.Log("Simple Curve: " + curve.Evaluate(0.8f));

        

        //Todo
    }

    public override void ThingPreDetroy()
    {
        base.ThingPreDetroy();
        //Todo
    }

    public override void ThingFixedUpdate()
    {
        base.ThingFixedUpdate();

        //Todo
    }

    public override void ThingUpdate()
    {
        base.ThingUpdate();
        //Todo
    }

    public override void ThingOnGUI()
    {
        base.ThingOnGUI();
        //Todo
    }


}
