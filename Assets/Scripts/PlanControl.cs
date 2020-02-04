using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myObject;
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
    
            if (Physics.Raycast (ray, out hit))
            {         
                Vector3  newPos = new Vector3(hit.point.x, 0.5f, hit.point.z);
                Instantiate(myObject, newPos, myObject.transform.rotation);
            }
        }
    }
    
}
