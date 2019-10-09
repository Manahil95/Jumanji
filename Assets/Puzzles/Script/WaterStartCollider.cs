using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStartCollider : MonoBehaviour
{
    public WaterMovement myWaterMovement;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ONOff")
        {
            if (myWaterMovement.FlowWater != null)
                myWaterMovement.FlowWater.Invoke(true);
            //myWaterMovement.CanFlow = true;
        }

        print(Time.time + " : " + myWaterMovement.CanFlow);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ONOff")
        {
            if (myWaterMovement.FlowWater != null)
                myWaterMovement.FlowWater.Invoke(false);
            //myWaterMovement.CanFlow = false;
        }

        print(Time.time + " : " + myWaterMovement.CanFlow);
    }
}
