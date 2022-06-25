using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using System.IO;

public static class VerbDefOf
{
    public static VerbDef attackFireball = new VerbDef("Verb_Attack_Fireball");
    public static VerbDef attackMeteorolite = new VerbDef("Verb_Attack_Meteorolite");
    public static VerbDef attackSplitFireball = new VerbDef("Verb_Attack_SplitFireball");
    public static VerbDef attackTrackFireball = new VerbDef("Verb_Attack_TrackFireball");
    public static VerbDef defendBasic = new VerbDef("Verb_Defend_BasicDefend");
    public static VerbDef movementBasic = new VerbDef("Verb_Movement_BasicMovement");
    public static VerbDef movementSwap = new VerbDef("Verb_Movement_Swap");
    public static VerbDef peek = new VerbDef("Verb_Movement_Swap");

    static VerbDefOf()
    {
        attackFireball.initialSeverity = 10;

        attackMeteorolite.initialSeverity = 20;

<<<<<<< Updated upstream:Assets/Scripts/Verb/VerbDefOf.cs
        attackSplitFireball.initialSeverity = 10;

        attackTrackFireball.initialSeverity = 10;

        //defendBasic

        //movementBasic
=======
        defendBasic.workerClass = typeof(Verb_Defend);
        movementBasic.workerClass = typeof(Verb_Move);
        peek.workerClass = typeof(Verb_Peek);
>>>>>>> Stashed changes:Assets/Scripts/GameScript/VerbDefOf.cs
    }

    //private static void AssignCardUITexture(VerbDef verbdef,string imagePath)
    //{
    //    FileStream fs = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
    //    byte[] thebytes = new byte[fs.Length];
    //    fs.Read(thebytes, 0, (int)fs.Length);
    //    Texture2D texture = new Texture2D(1, 1);
    //    texture.LoadImage(thebytes);
    //    attackFireball.UITextureCard =  texture;
    //}

    //private static void AssignIconUITexture(VerbDef verbdef, string imagePath)
    //{
    //    FileStream fs = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
    //    byte[] thebytes = new byte[fs.Length];
    //    fs.Read(thebytes, 0, (int)fs.Length);
    //    Texture2D texture = new Texture2D(1, 1);
    //    texture.LoadImage(thebytes);
    //    attackFireball.UITextureIcon = texture;
    //}
}
