using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Coroutines : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField task1_input;
    public InputField task2_input;
    public Text process1, process2;
    private int task1, task2;
    private WaitForSeconds timer = new WaitForSeconds(1.0f);

    void Start()
    {
        task1 = 0;
        task2 = 1;   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btnParalle_Click()
    {
        task1 =  int.Parse(task1_input.text);
        task2 = int.Parse(task2_input.text);
        //Debug.Log(task1_input.text);
        StartCoroutine(doParalelle());
        doParalelle();
    }
    public void btnRace_Click()
    {
        task1 =  int.Parse(task1_input.text);
        task2 = int.Parse(task2_input.text);
        //Debug.Log("btnRace_Click");
        StartCoroutine(doRace());
        doRace();
    }
    IEnumerator doParalelle()
    {
        int count = (task1 > task2) ? task1: task2;
        for (int i = 0; i < count; i++)
        {
            if(i<= task1) 
                process1.text = ""+i +" / " + task1;
            if(i<= task2) 
                process2.text = ""+i +" / " + task2;
            yield return timer;
        }
    }
    IEnumerator doRace(){
        int count = (task1 > task2) ? task2: task1;
        for (int i = 0; i <= count; i++)
        {
            process1.text = ""+i +" / " + task1;
            process2.text = ""+i +" / " + task2;
            yield return timer;
        }
    }
}
