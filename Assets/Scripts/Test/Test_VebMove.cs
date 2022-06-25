using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Test_VebMove : ThingComponent
{
    public override void CompUpdate()
    {
        base.CompUpdate();
        if (Input.GetMouseButtonDown(0))
        {
            //射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Verb_Move move = new Verb_Move();

            //射线检测的信息
            RaycastHit hit;
            Character character = parent as Character;
            //第四个参数是一个表示二进制位的数  比如第四个参数为5的时候  只有第0层和第2层可以别检测 因为5的二进制码是  101
            if (Physics.Raycast(ray, out hit, 100, 5))
            {
                Debug.Log(hit.point.x);
                Debug.Log(hit.point.z);
                move.TrySetTarget(new TargetInfo { location = new Vector3(hit.point.x, character.transform.position.y, hit.point.z) });
            }

            character.VerbTracker.AddVerb(move);
            character.VerbTracker.NextVerb();
        }
    }
}
