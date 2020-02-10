﻿using System.Collections;
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
    private bool isshow = true;

    void Start()
    {
        //itemManager = GameObject.Find("Plane").GetComponent<ItemManager>();
        collider = GetComponent<CapsuleCollider>();
        count = 0;
        SetCountText();
        winText.text = "";
        //Debug.Log(itemManager.listItem[0].transform.position);
        Debug.Log("Next");
    }

   void Update(){
        if (itemManager.listItem.Count > 0)
        {
            transform.LookAt(itemManager.listItem[0].transform.position, Vector3.up);
            transform.position = Vector3.MoveTowards(transform.position, itemManager.listItem[0].transform.position, Time.deltaTime * speed);
            
           collider.transform.position = transform.position;// (itemManager.listItem[0].transform.position);
            
            if (transform.position == itemManager.listItem[0].transform.position && isshow)
            {
                //Debug.Log(rb.transform.position);
                //Debug.Log(itemManager.listItem[0].transform.position);
                isshow = !isshow;
            }

        }
    }
    //void OnCollisionEnter (Collision other)
   void OnTriggerEnter(Collider other)
   {
      Debug.Log("Trigger Collision");
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
   public AnimationClip GetAnimationClip(Animator anim, string name) {
    if (!anim) return null; // no animator
 
    for (int i = 0; i < anim.runtimeAnimatorController.animationClips.Length; i++)
    {
        if (anim.runtimeAnimatorController.animationClips [i].name == name)
            return anim.runtimeAnimatorController.animationClips [i];
    }
    return null; // no clip by that name
 }
}