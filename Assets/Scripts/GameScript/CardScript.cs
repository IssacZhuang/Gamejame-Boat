using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    public VerbDef verbDef;

    //public Sprite fireballCard;
    //public Sprite fireballIcon;
    //public Sprite meteoroliteCard;
    //public Sprite meteoroliteIcon;
    //public Sprite defendCard;
    //public Sprite defendIcon;
    //public Sprite movementCard;
    //public Sprite movementIcon;
    //public Sprite peekCard;
    //public Sprite peekIcon;

    public CardScript()
    {

    }


    public void InitializeCard(VerbDef verbDef)
    {
        this.verbDef = verbDef;

        //if (verbDef.workerClass == typeof(Verb_ShootFireBall))
        //{
        //    this.GetComponent<Image>().sprite = fireballCard;
        //}
        //if (verbDef.workerClass == typeof(Verb_ShootMeteorite))
        //{
        //    this.GetComponent<Image>().sprite = meteoroliteCard;
        //}
        //if (verbDef.workerClass == typeof(Verb_Defend))
        //{
        //    this.GetComponent<Image>().sprite = defendCard;
        //}
        //if (verbDef.workerClass == typeof(Verb_Move))
        //{
        //    this.GetComponent<Image>().sprite = movementCard;
        //}
        //if (verbDef.workerClass == typeof(Verb_Peek))
        //{
        //    this.GetComponent<Image>().sprite = peekCard;
        //}

    }

    public void Onclick()
    {

    }
}
