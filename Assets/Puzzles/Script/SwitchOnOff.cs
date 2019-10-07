using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnOff : MonoBehaviour
{

    public GameObject Water;

    float Speed = 5f;
    Vector3 waterScale;
    public  bool GeneratesWater;
    public WaterTank MyWaterTank;


    void ScaleWater()
    {
        waterScale = Water.transform.localScale;
        waterScale.x += Time.deltaTime;
        Water.transform.localScale = waterScale;


    }

    private void OnTriggerEnter(Collider other)
    {
        print("Hi");
    }

    private void OnTriggerStay(Collider other)
    {
        if (MyWaterTank.Unlocked )
        {
            if (other.gameObject.tag == "ONOff")
            {
                print("Alesta");
                if(GeneratesWater)
                    InvokeRepeating("ScaleWater", 0, Time.deltaTime);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //CancelInvoke();
        //Destroy(Water);
    }
}
