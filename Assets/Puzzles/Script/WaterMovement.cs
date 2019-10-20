using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public WaterTank myWaterTank;
    public WaterTank NextWaterTank;
    public WaterScale waterScale;
    public bool WaterStartingPoint;
    public bool CanFlow;

    public Action<bool> FlowWater;

    Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        if (WaterStartingPoint)
            InvokeRepeating("MoveWaterSource", 0, Time.deltaTime);
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
        if (myWaterTank.Unlocked && CanFlow)
            MoveWaterSource();
        else
            RemoveWater();
    }

    void MoveWaterSource()
    {
        temp = transform.localScale;
        if (temp.x < 1.6f)
        {
            temp.x += Time.deltaTime;
            transform.localScale = temp;
        }
        else if (temp.x >= 1.6f)
        {
            CancelInvoke();
        }
    }

    void RemoveWater()
    {
        //if (!myWaterTank.Moving)
        //{
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
        //}
    }

    //void FillWaterTank()
    //{
    //    temp = transform.localScale;
    //    if (temp.x < 2.5f)
    //    {
    //        temp.x += Time.deltaTime;
    //        temp.y += Time.deltaTime;
    //        temp.z += Time.deltaTime;
    //        transform.localScale = temp;
    //    }
    //    else if (temp.x >= 2.5f)
    //    {
    //        CancelInvoke();
    //    }
    //}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ONOff")
        {
            NextWaterTank.Unlocked = true;

            if (NextWaterTank.unlocked != null)
                NextWaterTank.unlocked.Invoke(true);
            //print(name);
            //print(Time.time + " : " + NextWaterTank.name);
        }

        if (other.tag == "WaterExetCollider")
        {
            waterScale.InvokeRepeating("ScaleWater", 0, Time.deltaTime);
            //InvokeRepeating("FillWaterTank", 0, Time.deltaTime);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ONOff")
        {
            NextWaterTank.Unlocked = false;

            if (NextWaterTank.unlocked != null)
                NextWaterTank.unlocked.Invoke(false);
            //print(name);
            //print(Time.time + " : " + NextWaterTank.name);
        }
    }
}
