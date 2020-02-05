using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject myObject;
    public LayerMask layer;
    private PlayerController player;
    public GameObject objPlayer;
    public List<GameObject> listItem;
    void Start()
    {
       //player = objPlayer.GetComponent<PlayerController>();
       listItem = new List<GameObject>();
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
                GameObject obj = myObject.Spawn(hit.point);
                listItem.Add(obj);
            }
        }
    }
}
