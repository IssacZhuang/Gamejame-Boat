using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform camera;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAtPos = new Vector3(camera.position.x, this.transform.position.y, camera.position.z);

        Debug.Log(lookAtPos.x +" " + lookAtPos.y + " "+ lookAtPos.z);
        transform.LookAt(lookAtPos, Vector3.up);

    }
}
