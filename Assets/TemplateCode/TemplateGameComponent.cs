using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class TemplateGameComponent : GameComponent
{
    public override void GameFixedUpdate()
    {
        base.GameFixedUpdate();
        //Debug.Log("This is a global game componenet");
        //Todo
    }

    public override void GameUpdate()
    {
        base.GameUpdate();
        //Todo
    }

    public override void GameOnGUI()
    {
        base.GameOnGUI();
        //Todo
    }

    public override void GamePreDestroy()
    {
        base.GamePreDestroy();
        //Todo
    }
}
