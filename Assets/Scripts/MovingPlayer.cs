using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    public GameObject fromObj;
    public GameObject targetObj;
    [Range(0, 1)] public float t;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(fromObj.transform.position, targetObj.transform.position, t);
        transform.rotation = Quaternion.Lerp(fromObj.transform.rotation, targetObj.transform.rotation, t);
    }
}
