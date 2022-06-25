using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;

public class Test_VerbAttackFireBall : ThingComponent
{
    public GameObject attackObject;
    /*public override void CompPostStart()
    {
        base.CompPostStart();
        Verb_ShootFireBall shoot = new Verb_ShootFireBall();
        shoot.TrySetTarget(new TargetInfo { location = new Vector3(-1, 0, -1) });
        shoot.objct = attackObject;
        Character character = parent as Character;
    
        character.VerbTracker.AddVerb(shoot);
        character.VerbTracker.NextVerb();
    }*/

    public override void CompUpdate()
    {
        base.CompUpdate();
        if (Input.GetMouseButtonDown(0))
        {
            //����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Verb_ShootFireBall shoot = new Verb_ShootFireBall();

            //���߼�����Ϣ
            RaycastHit hit;
            Character character = parent as Character;
            //���ĸ�������һ����ʾ������λ����  ������ĸ�����Ϊ5��ʱ��  ֻ�е�0��͵�2����Ա��� ��Ϊ5�Ķ���������  101
            if (Physics.Raycast(ray, out hit, 100, 5))
            {
                Debug.Log(hit.point.x);
                Debug.Log(hit.point.z);
                shoot.TrySetTarget(new TargetInfo { location = new Vector3(hit.point.x, character.transform.position.y, hit.point.z) });
                shoot.objct = attackObject;
            }
            character.VerbTracker.AddVerb(shoot);
            character.VerbTracker.NextVerb();
        }
    }
}
