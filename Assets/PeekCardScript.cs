using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeekCardScript : MonoBehaviour
{
    public Button cardButton;
    bool isClicked = false;
    public Character player;
    public InteractionManager interactionManager;
    public Verb_Peek peek;
    // Start is called before the first frame update
    public void Start()
    {
        CardScript script = GetComponent<CardScript>();
        this.player = script.owner;

        Button btn = cardButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    public void Update()
    {
        if (isClicked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.peek = (Verb_Peek)VerbDefOf.movementBasic.CreateVerb();
                this.peek.TrySetTarget(new TargetInfo { location = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z) });
                TaskOnReadyClick();
            }

        }
    }
    public void TaskOnReadyClick()
    {
        interactionManager.FillSlot(peek);
        isClicked = false;

    }

    public void TaskOnClick()
    {
        isClicked = true;

    }
}
