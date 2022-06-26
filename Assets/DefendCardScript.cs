using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefendCardScript : MonoBehaviour
{
    public Button yourButton;
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

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    public void Update()
    {
        if (isClicked)
        {
            if (!isShieldGenerated)
            {
                // add the defend verb into the queue
                Verb_Defend shield = (Verb_Defend)VerbDefOf.defendBasic.CreateVerb();

                shield.objct = shieldObj;

                player.VerbTracker.AddVerb(shield);
                player.VerbTracker.NextVerb();
                isShieldGenerated = true;
            }

        }

        //if (player.VerbTracker.pendingVerbs.Count != 0 && player.VerbTracker.pendingVerbs.Count == 2)
        //{

        //}
    }
    public void TaskOnClick()
    {

        interactionManager.FillSlot(shield);
        isClicked = true;

    }
}
