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
    public GameObject Step10;
    public GameObject Step11;
    public GameObject Step12;
    public GameObject Step13;
    public GameObject Step14;
    public GameObject Step15;
    public GameObject Step16;
    public GameObject Step17;
     
    void Start()
    {
        // Invoke("SpawnObject", 2);
        Invoke("S1", 0.5f);
        Invoke("S2", 1);
        Invoke("S3", 1.5f);
        Invoke("S4", 2);
        Invoke("S5", 2.5f);
        Invoke("S6", 3);
        Invoke("S7", 3.5f);
        Invoke("S8", 4);
        Invoke("S9", 4.5f);
        Invoke("S10", 5);
        Invoke("S11", 5.5f);
        Invoke("S12", 6);
        Invoke("S13", 6.5f);
        Invoke("S14", 7);
        Invoke("S15", 7.5f);
        Invoke("S16", 8);
        Invoke("S17", 8.5f);
    }


private void  SpawnObject()//IEnumerator
    {
       for(int i =0; i <= Steps.Length; i++)
        {
            Steps[i].SetActive(true);
            //yield return new WaitForSeconds(2);
            //yield return new WaitForSeconds(0.1f);
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
    private void S10()
    {
        Step10.SetActive(true);
    }
    private void S11()
    {
        Step11.SetActive(true);
    }
    private void S12()
    {
        Step12.SetActive(true);
    }
    private void S13()
    {
        Step13.SetActive(true);
    }
    private void S14()
    {
        Step14.SetActive(true);
    }
    private void S15()
    {
        Step15.SetActive(true);
    }
    private void S16()
    {
        Step16.SetActive(true);
    }
    private void S17()
    {
        Step17.SetActive(true);
    }
}
