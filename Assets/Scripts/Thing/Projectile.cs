using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Projectile : Thing
{
    private GameObject projectile;
    private float speed = 5.0f;
    private Vector2 direction;
    private long startTime;
    

    // Start is called before the first frame update
    void Start()
    {
        startTime = Find.CurrentGame.GlobalTick;
    }

    // Update is called once per frame
    public override void ThingFixedUpdate()
    {
        projectile.transform.Translate(new Vector3(direction.x * speed * Time.deltaTime, 0,direction.y * speed * Time.deltaTime));

        //越界判断
        if (Find.CurrentGame.GlobalTick - startTime > 50*5) //at most last 5s
        {
            Destroy();
        }
    }

    void OnDestroy()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();
        if (character != null)
        {
            HitCharacter(character);
        }
    }

    public virtual void HitCharacter(Character character)
    {
        character.BuffTracker.TryAddBuff(BuffDefOf.attack);
    }
}
