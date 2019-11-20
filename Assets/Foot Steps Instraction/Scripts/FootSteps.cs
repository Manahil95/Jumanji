using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public GameObject[] Steps;
    public GameObject Step1;
    public GameObject Step2;
    public GameObject Step3;
    public GameObject Step4;
    public GameObject Step5;
    public GameObject Step6;
    public GameObject Step7;
    public GameObject Step8;
    public GameObject Step9;
    void Start()
    {
        // Invoke("SpawnObject", 2);
        Invoke("S1", 2);
        Invoke("S2", 4);
        Invoke("S3", 8);
        Invoke("S4", 10);
        Invoke("S5", 12);
        Invoke("S6", 14);
        Invoke("S7", 16);
        Invoke("S8", 18);
        Invoke("S9", 20);
    }


private void  SpawnObject()//IEnumerator
    {
       for(int i =0; i <= Steps.Length; i++)
        {
            Steps[i].SetActive(true);
            //yield return new WaitForSeconds(2);
           
        }
    }
    private void S1()
    {
        Step1.SetActive(true);
    }
    private void S2()
    {
        Step2.SetActive(true);
    }
    private void S3()
    {
        Step3.SetActive(true);
    }
    private void S4()
    {
        Step4.SetActive(true);
    }
    private void S5()
    {
        Step5.SetActive(true);
    }
    private void S6()
    {
        Step6.SetActive(true);
    }
    private void S7()
    {
        Step7.SetActive(true);
    }
    private void S8()
    {
        Step8.SetActive(true);
    }
    private void S9()
    {
        Step9.SetActive(true);
    }
}
