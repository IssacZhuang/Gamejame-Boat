using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : Scaffold.Thing
{
    public bool isFilled;
    public Image slotIcon;

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

    }

    public void RemoveIcon(Verb verb)
    {

    }

}
