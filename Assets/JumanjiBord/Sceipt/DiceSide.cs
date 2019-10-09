using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour
{
    bool onGround;
    public int sideValue;

    void OnTriggerStay(Collider other)
    {
        if(other.tag =="Bord")
        {
            onGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bord")
        {
            onGround = false;
        }
    }

    public bool OnGround()
    {
        return onGround;
    }
}
