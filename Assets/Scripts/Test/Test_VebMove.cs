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
            //����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Verb_Move move = new Verb_Move();

            //���߼�����Ϣ
            RaycastHit hit;
            Character character = parent as Character;
            //���ĸ�������һ����ʾ������λ����  ������ĸ�����Ϊ5��ʱ��  ֻ�е�0��͵�2����Ա��� ��Ϊ5�Ķ���������  101
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
