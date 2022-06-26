using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : Scaffold.Thing
{
    public bool isFilled;
    public bool isPeek;
    public Image slotIcon;


    public Sprite fireballIcon;
    public Sprite splitFireballIcon;
    public Sprite meteoroliteIcon;
    public Sprite defendIcon;
    public Sprite movementIcon;
    public Sprite peekIcon;

    private void Start()
    {
        isFilled = false;
        slotIcon = this.GetComponent<Image>();
    }
    public SlotScript()
    {

    }

    public void SetIcon(Sprite sprite)
    {
        slotIcon.sprite = sprite;
        isFilled = true;
    }

    public void SetIcon(VerbDef verbDef)
    {
        if (verbDef == VerbDefOf.attackFireball)
        {
            SetIcon(fireballIcon);
        }
        if (verbDef == VerbDefOf.attackSplitFireball)
        {
            SetIcon(splitFireballIcon);
        }
        if (verbDef == VerbDefOf.attackMeteorolite)
        {
            SetIcon(meteoroliteIcon);
        }
        if (verbDef == VerbDefOf.defendBasic)
        {
            SetIcon(defendIcon);
        }
        if (verbDef == VerbDefOf.movementBasic)
        {
            SetIcon(movementIcon);
        }
        if (verbDef == VerbDefOf.peek)
        {
            SetIcon(peekIcon);
        }
    }

    public void RemoveIcon()
    {
        slotIcon.sprite = null;
        isFilled = false;
        isPeek = false;
    }

}
