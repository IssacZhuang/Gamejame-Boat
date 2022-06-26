using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBallCardScript : MonoBehaviour
{
    public Button yourButton;
    public GameObject fireBall;
    bool isClicked = false;
    Character player;
    public InteractionManager interactionManager;
    Verb_ShootFireBall shoot;
    // Start is called before the first frame update
    public void Start()
    {
        CardScript script = GetComponent<CardScript>();
        shoot = (Verb_ShootFireBall)VerbDefOf.attackFireball.CreateVerb();
        player = script.owner;

        Button btn = yourButton.GetComponent<Button>();
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
                Verb_ShootFireBall shoot = (Verb_ShootFireBall)VerbDefOf.attackFireball.CreateVerb();

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, 5))
                {
                    shoot.TrySetTarget(new TargetInfo { location = new Vector3(hit.point.x, player.transform.position.y, hit.point.z) });
                    shoot.objct = fireBall;
                    
                }

                player.VerbTracker.AddVerb(shoot);
                player.VerbTracker.NextVerb();
            }

        }

        //if (player.VerbTracker.pendingVerbs.Count != 0 && player.VerbTracker.pendingVerbs.Count == 2)
        //{

        //}
    }
    public void TaskOnClick()
    {

        interactionManager.FillSlot(shoot);
        isClicked = true;

    }
}
