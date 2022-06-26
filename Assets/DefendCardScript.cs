using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefendCardScript : MonoBehaviour
{
    public Button cardButton;
    public Button selectedButton;
    public GameObject shieldObj;
    bool isClicked = false;
    Character player;
    public InteractionManager interactionManager;
    bool isShieldGenerated = false;
    Verb_Defend shield;

    // Start is called before the first frame update
    public void Start()
    {
        CardScript script = GetComponent<CardScript>();
        shield = (Verb_Defend)VerbDefOf.defendBasic.CreateVerb();
        player = script.owner;

        Button btn = cardButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Button seletbtn = selectedButton.GetComponent<Button>();
        seletbtn.onClick.AddListener(TaskOnReadyClick);
    }

    // Update is called once per frame
    public void Update()
    {
        if (isClicked)
        {
            Verb_Defend shield = (Verb_Defend)VerbDefOf.defendBasic.CreateVerb();

            //if (!isShieldGenerated)
            //{
            //    // add the defend verb into the queue
            //    // Verb_Defend shield = (Verb_Defend)VerbDefOf.defendBasic.CreateVerb();
            //    //shield.objct = shieldObj;
            //    //player.VerbTracker.AddVerb(shield);
            //    //player.VerbTracker.NextVerb();
            //    //isShieldGenerated = true;
            //}

        }
    }
    public void TaskOnReadyClick()
    {
        if (isClicked)
        {
            interactionManager.FillSlot(shield);
            isClicked = false;
        }

    }
    public void TaskOnClick()
    {
        isClicked = true;

    }
}
