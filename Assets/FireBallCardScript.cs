using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBallCardScript : MonoBehaviour
{
    public Button cardButton;
    public Button selectedButton;
    public GameObject fireBall;
    bool isClicked = false;
    public Character player;
    public InteractionManager interactionManager;
    public Verb_ShootFireBall shoot;
    // Start is called before the first frame update
    public void Start()
    {
        CardScript script = GetComponent<CardScript>();
        this.shoot = (Verb_ShootFireBall)VerbDefOf.attackFireball.CreateVerb();
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
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                this.shoot = (Verb_ShootFireBall)VerbDefOf.attackFireball.CreateVerb();

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, 5))
                {
                    this.shoot.TrySetTarget(new TargetInfo { location = new Vector3(hit.point.x, player.transform.position.y, hit.point.z) });
                    this.shoot.objct = fireBall;
                    
                }

                //player.VerbTracker.AddVerb(shoot);
                //player.VerbTracker.NextVerb();
            }

        }

        //if (player.VerbTracker.pendingVerbs.Count != 0 && player.VerbTracker.pendingVerbs.Count == 2)
        //{

        //}
    }

    public void TaskOnReadyClick()
    {
        if (this.isClicked)
        {
            interactionManager.FillSlot(shoot);
            isClicked = false;
        }

    }

    public void TaskOnClick()
    {

        isClicked = true;

    }
}
