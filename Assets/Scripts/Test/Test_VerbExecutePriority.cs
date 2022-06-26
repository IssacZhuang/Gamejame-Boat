using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Scaffold;

public class Test_VerbExecutePriority : GameComponent
{
    public void Start()
    {
        StageManager stageManager = GetComponent<StageManager>();
        for (int i = 0; i < 4; i++)
        {
            stageManager.AddNewCharacter(i%2);
        }

        VerbDef verb1 = new VerbDef { defName = "1", priority = 1 };
        VerbDef verb2 = new VerbDef { defName = "2", priority = 3 };
        VerbDef verb3 = new VerbDef { defName = "3", priority = 2 };
        VerbDef verb4 = new VerbDef { defName = "4", priority = 4 };

        stageManager.Characters.ElementAt(0).VerbTracker.AddVerb(verb1.CreateVerb());
        stageManager.Characters.ElementAt(1).VerbTracker.AddVerb(verb2.CreateVerb());
        stageManager.Characters.ElementAt(2).VerbTracker.AddVerb(verb3.CreateVerb());
        stageManager.Characters.ElementAt(3).VerbTracker.AddVerb(verb4.CreateVerb());

        stageManager.SortCharacter();
        stageManager.DebugPrintSoertedCharacterVerb();


    }
}
