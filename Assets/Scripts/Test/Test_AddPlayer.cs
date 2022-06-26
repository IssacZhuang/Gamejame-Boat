using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Test_AddPlayer : GameComponent
{
    public void Start()
    {
        StageManager stageManager = GetComponent<StageManager>();
        for(int i = 0; i < 4; i++)
        {
            stageManager.AddNewCharacter(i%2);
        }
        
    }
}
