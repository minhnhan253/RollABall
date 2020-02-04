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
    private Vector3 targetPos;
    private Vector3 currPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        targetPos = currPos = transform.position;
    }
   void Update(){

   }
   void FixedUpdate(){
       if(targetPos != currPos)
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
   }
   void OnTriggerEnter(Collider other)
   {
      if(other.gameObject.CompareTag("Pick Up"))
      {
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
   public void SetTargetPos(Vector3 pos)
   {
       targetPos = pos;
       
   }
}