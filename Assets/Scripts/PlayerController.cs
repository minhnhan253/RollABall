using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int count;
    public Text countText;
    public Text winText;
    private CapsuleCollider collider;
    public float speed;
    public ItemManager itemManager;
    private bool isPlayedAnim = false;
    private Animator animator;

    void Start()
    {
        //itemManager = GameObject.Find("Plane").GetComponent<ItemManager>();
        collider = GetComponent<CapsuleCollider>();
        count = 0;
        SetCountText();
        winText.text = "";
        //Debug.Log(itemManager.listItem[0].transform.position);
        Debug.Log("Next");
        animator = GetComponent<Animator>();
    }

   void Update(){
        if (itemManager.listItem.Count > 0)
        {
            transform.LookAt(itemManager.listItem[0].transform.position, Vector3.up);
            transform.position = Vector3.MoveTowards(transform.position, itemManager.listItem[0].transform.position, Time.deltaTime * speed);
            
           //collider.transform.position = transform.position;// (itemManager.listItem[0].transform.position);
            
            if (!isPlayedAnim)
            {
                //Debug.Log(rb.transform.position);
                //Debug.Log(itemManager.listItem[0].transform.position);
                
                animator.SetTrigger("walking");
                isPlayedAnim = true;
            }

        }
    }
    //void OnCollisionEnter (Collision other)
   void OnTriggerEnter(Collider other)
   {
      Debug.Log("Trigger Collision");
      isPlayedAnim = false;
      animator.SetTrigger("idle");
      if(other.gameObject.CompareTag("Pick Up"))
      {
        itemManager.listItem.Remove(other.gameObject);
        count ++;
        SetCountText();
        other.gameObject.Kill();
      }

   }
   void SetCountText()
   {
       countText.text = "Count: " + count.ToString();
       if (count >= 12)
        winText.text = "You Win";
   }
}