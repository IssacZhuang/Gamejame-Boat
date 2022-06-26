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
    void Start()
    {
        CardScript script = GetComponent<CardScript>();

        player = script.owner;

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            if (!isShieldGenerated)
            {
                // add the defend verb into the queue
                shield = new Verb_Defend();

                shield.objct = shieldObj;

                player.VerbTracker.AddVerb(shield);
                player.VerbTracker.NextVerb();
                isShieldGenerated = true;
            }

            interactionManager.FillSlot(shield);
        }

        //if (player.VerbTracker.pendingVerbs.Count != 0 && player.VerbTracker.pendingVerbs.Count == 2)
        //{

        //}
    }
    void TaskOnClick()
    {

        isClicked = true;

    }
}
