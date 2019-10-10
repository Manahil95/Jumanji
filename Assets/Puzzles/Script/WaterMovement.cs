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
        if (temp.x < 2.3f)
        {
            temp.x += Time.deltaTime;
            transform.localScale = temp;
        }
        else if (temp.x >= 2.3f)
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
