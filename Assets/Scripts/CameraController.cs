using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private List<Camera> list;
    public Camera camera1;
    public Camera camera2;
    public Camera movingCamera;
    // Start is called before the first frame update
    private float time = 0;
    void Start()
    {
        camera1.enabled = false;
        camera2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += 0.5f*Time.deltaTime;
        //if (Input.GetKeyUp(KeyCode.Space))
        {   
            movingCamera.transform.position = Vector3.Lerp(camera1.transform.position, camera2.transform.position, time);
            movingCamera.transform.rotation = Quaternion.Lerp(camera1.transform.rotation, camera2.transform.rotation, time);
            
        }
    }
}
