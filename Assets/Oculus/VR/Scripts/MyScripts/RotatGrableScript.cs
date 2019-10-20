using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatGrableScript : OVRGrabber
{

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.tag == "Rotater")
        {
            otherCollider.GetComponent<RotateController>().handInitialPos = transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Rotater")
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                other.GetComponent<RotateController>().ActivateRotator();
            }
        }
    }
}
