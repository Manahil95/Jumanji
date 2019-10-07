using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTank : MonoBehaviour
{
    //public Transform myTransform;
    public float YRotation;
    public Quaternion TargetRotation;
    public bool Unlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Unloked")
            Unlocked = true;
    }
}
