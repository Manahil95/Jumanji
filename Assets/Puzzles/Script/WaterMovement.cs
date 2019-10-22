using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public WaterTank myWaterTank;
    public WaterTank NextWaterTank;
    public bool WaterStartingPoint;
    public bool CanFlow;
    public float WaterSize;
    public AudioSource waterFlowSound;
    public Action<bool> FlowWater;
    Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        waterFlowSound = GetComponent<AudioSource>();

        if (WaterStartingPoint)
            InvokeRepeating("FillWater", 0, Time.deltaTime);
        else
        {
            FlowWater += StartFlowing;
            myWaterTank.unlocked += UnlockTank;
        }
    }

    private void UnlockTank(bool unlocked)
    {
        myWaterTank.Unlocked = unlocked;
        CancelInvoke();
        InvokeRepeating("WaterFlowing", 0, Time.deltaTime);
    }

    void StartFlowing(bool canFlow)
    {
        CanFlow = canFlow;
        CancelInvoke();
        InvokeRepeating("WaterFlowing", 0, Time.deltaTime);
    }

    void WaterFlowing()
    {
        //if (!myWaterTank.Moving)
        //{
            if (myWaterTank.Unlocked && CanFlow)
                FillWater();
            else
                EmptyeWater();
        //}
    }

    void FillWater()
    {
        
        temp = transform.localScale;
        if (temp.x < WaterSize)
        {
            temp.x += Time.deltaTime;
            transform.localScale = temp;
            waterFlowSound.Play();
        }
        else if (temp.x >= WaterSize)
        {
            CancelInvoke();
        }
    }

    void EmptyeWater()
    {
        temp = transform.localScale;
        if (temp.x > 0)
        {
            temp.x -= Time.deltaTime;
            transform.localScale = temp;
        }
        else if (temp.x <= 0)
        {
            CancelInvoke();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ONOff")
        {
            NextWaterTank.Unlocked = true;

            if (NextWaterTank.unlocked != null)
                NextWaterTank.unlocked.Invoke(true);
        }

        if (other.tag == "WaterExetCollider")
        {
            other.GetComponent<FillTank>().InvokeRepeating("RaiseWater", 0, Time.deltaTime);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ONOff")
        {
            NextWaterTank.Unlocked = false;

            if (NextWaterTank.unlocked != null)
                NextWaterTank.unlocked.Invoke(false);
        }
    }
}
