using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCardScript : MonoBehaviour
{
    public Button cardButton;
    bool isClicked = false;
    public Character player;
    public InteractionManager interactionManager;
    public Verb_Move move;
    // Start is called before the first frame update
    public void Start()
    {
        CardScript script = GetComponent<CardScript>();
        this.move = (Verb_Move)VerbDefOf.movementBasic.CreateVerb();
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
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Verb_Move move = (Verb_Move)VerbDefOf.movementBasic.CreateVerb();

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, 5))
                {
                    this.move.TrySetTarget(new TargetInfo { location = new Vector3(hit.point.x, player.transform.position.y, hit.point.z) });
                    TaskOnReadyClick();
                }

                //player.VerbTracker.AddVerb(move);
                //player.VerbTracker.NextVerb();
            }

        }

        //if (player.VerbTracker.pendingVerbs.Count != 0 && player.VerbTracker.pendingVerbs.Count == 2)
        //{

        //}
    }
    public void TaskOnReadyClick()
    {
        interactionManager.FillSlot(move);
        isClicked = false;

    }

    public void TaskOnClick()
    {
        isClicked = true;

    }
}
