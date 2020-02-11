using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    private List<Camera> list;
    private int currIdx = 0;
    public Camera camera1;
    public Camera camera2;
    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - player.transform.position;
        // list.Add(camera1);
        // list.Add(camera2);
        camera1.enabled = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       // transform.position = player.transform.position + offset;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (camera1.isActiveAndEnabled)
            {
                camera1.enabled = false;
                camera2.enabled = true;
            }
            else
            {
                camera1.enabled = true;
                camera2.enabled = false;
            }
        }
    }
}
