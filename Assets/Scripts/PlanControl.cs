using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myObject;
    public LayerMask layer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
            RaycastHit hit = new RaycastHit();
    
            if (Physics.Raycast (ray, out hit, 1000, layer))
            {         
                //Vector3  newPos = new Vector3(hit.point.x, 0.5f, hit.point.z);
                //Instantiate(myObject, newPos, myObject.transform.rotation);
                myObject.Spawn(hit.point);
                Debug.Log(hit.point);
            }
        }
    }
    
}
