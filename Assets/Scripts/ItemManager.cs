using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
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
                myObject.Spawn(hit.point);
                Debug.Log(hit.point);
            }
        }
    }
}
