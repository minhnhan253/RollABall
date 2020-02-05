using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Animator anim;
    private List<string> animList;
    void Start() {
        animList.Add("prefab_blue");
        animList.Add("prefab_green");
        animList.Add("prefab_red");
        anim = GetComponent<Animator>();
        anim.Play("prefab_blue");
        Debug.Log("calll!!!!!!!!!!!!!!!!");
    }
    // Update is called once per frame
    void Update()
    {
        if (!AnimatorIsPlaying())
        {
            anim.Play("prefab_green");
        }
    }

    bool AnimatorIsPlaying(){
     return anim.GetCurrentAnimatorStateInfo(0).length >
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
  }
}
