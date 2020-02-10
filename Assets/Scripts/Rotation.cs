using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Animator anim;
    private string[] animList;
    private int currAnimId = 0;
    void Start() {
        currAnimId = 0;
        animList = new string[3];
        animList.Initialize();
        animList.SetValue("red", 0);
        animList.SetValue("green",1);
        animList.SetValue("blue", 2);
        anim = GetComponent<Animator>();
       anim.SetTrigger("red");
        GetComponent<ParticleSystem>().Stop();
    }
    // Update is called once per frame
    void Update()
    {
        // if (anim.GetCurrentAnimatorStateInfo(0).IsName("prefab_red"))
        //     Debug.Log("red");
        if (!AnimatorIsPlaying())
        {
            TriggerAnim();
        }
    }

    bool AnimatorIsPlaying(){
     return anim.GetCurrentAnimatorStateInfo(0).length >
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    void TriggerAnim()
    {
        currAnimId =  (currAnimId >= animList.Length - 1) ? 0 : currAnimId+1;
        anim.SetTrigger(animList.GetValue(currAnimId).ToString());
    }
}
