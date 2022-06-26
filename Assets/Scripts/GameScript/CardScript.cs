using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    public VerbDef verbDef;
    public Character owner;

    public CardScript()
    {

    }


    public void InitializeCard(VerbDef verbDef,Character owner)
    {
        this.verbDef = verbDef;
        this.owner = owner;

    }

    public void Onclick()
    {

    }
}