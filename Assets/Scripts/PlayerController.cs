using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int count;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    public float speed;
    public ItemManager itemManager;

    void Start()
    {
        //itemManager = GameObject.Find("Plane").GetComponent<ItemManager>();
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

   void Update(){
       if (itemManager.listItem.Count> 0)
       {
            transform.position = Vector3.MoveTowards(transform.position, itemManager.listItem[0].transform.position, Time.deltaTime * speed);
       }
   }
   void OnTriggerEnter(Collider other)
   {
      if(other.gameObject.CompareTag("Pick Up"))
      {
          itemManager.listItem.Remove(other.gameObject);
          other.gameObject.Kill();
          count ++;
          SetCountText();
      }

   }
   void SetCountText()
   {
       countText.text = "Count: " + count.ToString();
       if (count >= 12)
        winText.text = "You Win";
   }
}