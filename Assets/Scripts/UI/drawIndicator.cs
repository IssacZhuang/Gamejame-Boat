using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawIndicator : MonoBehaviour
{
    public Mesh arrowMesh;
    public Material arrowMaterial;

    public Mesh targetMesh;
    public Material targetMaterial;
    public GameObject player;

    public void Update()
    {
        //player = GameObject.Find("Player1(Clone)");
        if (player != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, 5))
            {
                Vector3 location = new Vector3(hit.point.x, hit.point.y + 0.2f, hit.point.z);

                Vector3 direction = new Vector3(location.x - player.transform.position.x, 0, location.z - player.transform.position.z);

                Vector3 scale = new Vector3(0.3f, 0.3f, 1f);
                Vector3 drawArrowPos = new Vector3(player.transform.position.x, 0.2f, player.transform.position.z);
                Matrix4x4 arrowMatrix = Matrix4x4.TRS(drawArrowPos, Quaternion.LookRotation(direction, Vector3.up), scale);

                Graphics.DrawMesh(arrowMesh, arrowMatrix, arrowMaterial, 0);

                Vector3 targetScale = new Vector3(0.15f, 0.15f, 0.15f);

                Matrix4x4 targetMatrix = Matrix4x4.TRS(location, Quaternion.identity, targetScale);

                Graphics.DrawMesh(targetMesh, targetMatrix, targetMaterial, 0);

            }
        }
        // will make the mesh appear in the Scene at origin position
        //Graphics.DrawMesh(arrowMesh, Vector3.zero, Quaternion.identity, arrowMaterial, 0);
    }

    public void SetPlayer(GameObject targetPlayer)
    {
        player = targetPlayer;
    }
    public void UnsetPlayer(GameObject targetPlayer)
    {
        player = null;
    }

}
