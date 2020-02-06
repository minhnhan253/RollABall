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
        animList.SetValue("prefab_blue", 0);
        animList.SetValue("prefab_green",1);
        animList.SetValue("prefab_red", 2);
        anim = GetComponent<Animator>();
        anim.Play(animList.GetValue(currAnimId).ToString());
    }
    // Update is called once per frame
    void Update()
    {
        if (!AnimatorIsPlaying())
        {
            SetAnim();
        }
    }

    bool AnimatorIsPlaying(){
     return anim.GetCurrentAnimatorStateInfo(0).length >
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    void SetAnim()
    {
        currAnimId =  (currAnimId >= animList.Length - 1) ? 0 : currAnimId+1;
        anim.Play(animList.GetValue(currAnimId).ToString());
    }
}
